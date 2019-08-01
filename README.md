# LevelUpLarry2DSS
Larry is travelling through a 2D side scrolling environment when he is confronted by a horde of creatures ( slimes, skeletons, etc ).  

Based off [Design doc](https://docs.google.com/document/d/1iMpK-hJsFLI4GPMWzvPedDiAtvYZl5U48OwvbeyLm2I/edit#heading=h.19u0nz2irg77) on Google Docs.  This project is the `Larry vs Twitch Chat` idea.

In order to use this project, you must use UE4 v4.21.2.

## Installation

 - Download and install Twitchworks plugin via Epic Games Launcher
 - Follow the tutorial steps to set up your own project so you can see where the game files need to be copied.  
 - Clone the repository & put the files in a similar file structure as the sample game
   - Note: This repo uses Git LFS, so you must enable that via commandline or use a Git GUI like [SourceTree (Recommended)](https://www.sourcetreeapp.com/) which automatically supports Git LFS
 - Open the .uproject file and you'll see the game in the editor
 - Open up the Procedural_Level file under `Content\2DSideScrollerBP\Maps` and click the play button to play
 - If you want it to be full screen, there's an option next to play button to launch in different resolutions
 
## Launching
 - To Launch game without the editor, right click on UE4/LaunchGame.ps1 and Run in Powershell
   - To set resolution adjust the resx & resy commands in the script

 
See UE4 documentation for more info on how to run a game via the editor and how to publish a game.

## Project Status

Right now this is still a prototype and currently in development.  The upcoming tasks are tracked in Trello.  Please ask Larry for permission to view it :)
 
## Features
 
 ### Enemy Spawning Logic
 - Spawns on spawn points right now, tries to spawn them every 1 second if there are any in the queue & if Larry is not currently moving
 - Spawns enemies at least X units away from Larry, so they spawn off screen
 - Pulls enemies off the queue to determine which enemy type to spawn
 - Enemies are added to the queue by either RandomEnemyGenerator (for testing) or via Twitch Integration
 - RandomEnemyGenerator simulates Twitch Integration by adding to the EnemyQueue random EnemyProfiles at random times
 - There can only be one enemy per user alive or in the queue at a time.  This logic is handled by the EnemyQueuePermissions
 
 ### Twitch Integration
 - To enable twitch integration, download the TwitchWorks plugin & follow the instructions to enable it
 - It's enabled by default in the build, so if that's not desired there are many classes that can be deleted or cleaned up
 - In EnemySpawnerGameMode, turn on the twitch integration boolean
 - Please when making changes turn off the twitch integration and use the random enemy spawner instead, twitch integration should only be turned on for publishing
 
 ### Procedural Levels
 - Each section of the level is represented by a "Tile" Blueprint
 - Each Tile blueprint contains a TileMap, which is where the actual art and collision comes from
 - Tile blueprint also has volumes that when triggered attempt to spawn the next tile
 - Right now tiles are only spawned if the player is moving in that direction and they too close to the edge ( ex. 2 tiles away )
 - Tile blueprint also contains spawnpoints for enemies
 
  ### Boss Spawning Logic
 - Create a UI Widget that handles leveling up the boss's health
 - Emojis spammed by the audience fill up the health bar
 - After bar is full or X seconds, end the powering up stage & start spawning
 - After boss is killed, resume normal gameplay seamlessly
 - Boss Spawns when the Boss Tile is touched
 - Boss Tile is spawned once the next tile is spawned after X enemies are dead
 
 ### Twitch Emote Handling
 
 Currently broken waiting on TwitchWorks plugin update - right now just uses hard coded larry emotes
 
 - When user sends a message, delegate is called
 - TODO TwitchEmoteDownloader will bind to the delegate & download the textures
 - TwitchEmoteDownloader also starts downloading emotes as soon as the user connects to the channel
 - Textures will be stored by Hash of EmoteName -> Texture 
 - TODO Boss/EmoteSpawner will request a texture from TwitchEmoteDownloader
 - TODO If no texture is found a default will be returned
