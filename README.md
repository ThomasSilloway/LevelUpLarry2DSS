# LevelUpLarry2DSS
Larry is travelling through a 2D side scrolling environment when he is confronted by a horde of creatures ( slimes, skeletons, etc ).  

Based off [Design doc](https://docs.google.com/document/d/1iMpK-hJsFLI4GPMWzvPedDiAtvYZl5U48OwvbeyLm2I/edit#heading=h.19u0nz2irg77) on Google Docs.  This project is the `Larry vs Twitch Chat` idea.

In order to use this project, you must use UE4 v4.21.2.

## Installation

 - Follow the tutorial steps to set up your own project so you can see where the game files need to be copied.  
 - Clone the repository & put the files in a similar file structure as the sample game
   - Note: This repo uses Git LFS, so you must enable that via commandline or use a Git GUI like [SourceTree (Recommended)](https://www.sourcetreeapp.com/) which automatically supports Git LFS
 - Open the .uproject file and you'll see the game in the editor
 - Open up the LongMap file under `Content\2DSideScrollerBP\Maps` and click the play button to play
 - If you want it to be full screen, there's an option next to play button to launch in different resolutions
 
See UE4 documentation for more info on how to run a game via the editor and how to publish a game.

## Project Status

Right now this is still a prototype and currently in development.

The next phases to get to a Proof of Concept are:
 - Procedurally generated infinite scrolling level - in progress by Mr stabby
 
## Features
 
 Enemy Spawning Logic
 - Spawns on spawn points right now, tries to spawn them every 1 second if there are any in the queue & if Larry is not currently moving
 - Spawns enemies at least X units away from Larry, so they spawn off screen
 - Pulls enemies off the queue to determine which enemy type to spawn
 - Enemies are added to the queue by either RandomEnemyGenerator (for testing) or via Twitch Integration
 - RandomEnemyGenerator simulates Twitch Integration by adding to the EnemyQueue random EnemyProfiles at random times
 - There can only be one enemy per user alive or in the queue at a time.  This logic is handled by the EnemyQueuePermissions
 
 Twitch Integration
 - To enable twitch integration, download the TwitchWorks plugin & follow the instructions to enable it
 - In EnemySpawnerGameMode, turn on the twitch integration boolean
 - Please when making changes turn off the twitch integration and use the random enemy spawner instead, twitch integration should only be turned on for publishing
