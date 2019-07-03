# LevelUpLarry2DSS
Larry is travelling through a 2D side scrolling environment when he is confronted by a horde of creatures ( zombies, medieval army, wild animals? ).  

Based off [Design doc](https://docs.google.com/document/d/1iMpK-hJsFLI4GPMWzvPedDiAtvYZl5U48OwvbeyLm2I/edit#heading=h.19u0nz2irg77) on Google Docs.  This project is the `Larry vs Twitch Chat` idea.

In order to use this project, you must use UE4 v4.21.2

Right now this is still a prototype and currently in development.

The next phases to get to a Proof of Concept are:
 - Procedurally generated infinite scrolling level
   - TODO: Iron out a few issues with initial PR
   - TODO: Hook up an actual set of tiles from example content
 
Polish
 - Don't move camera until Larry gets to X percentage of the screen in either direction, so he can run back and forth without moving the camera.  
 - Once the camera doesn't move all the time with simple movement, adjust spawning system to pause spawns if camera isn't moving instead of character
 - Hook up loading UI for when logging into twitch
 - Rework collision for Enemies so it uses Box component as primary component
   - This involves remaking the enemy as not a pawn & then reworking the movement because it's unlikely the current movement system will work, player movement component may not be able to be added to non-pawns
 - Add multiple blob enemies from Larry's content package - In progress - TODO: Add blue, red & green are in
 - Add additional AI behaviors
 - Choose different enemies / behaviors for subs/followers/normal
 - Add XP bar
 
 Enemy Spawning Logic
 - Spawns on spawn points right now, tries to spawn them every 1 second if there are any in the queue & if Larry is not currently moving
 - Spawns enemies at least X units away from Larry, so they spawn off screen
 - Pulls enemies off the queue to determine which enemy type to spawn
 - Enemies are added to the queue by either RandomEnemyGenerator (for testing) or via Twitch Integration ( coming soon )
 - RandomEnemyGenerator simulates Twitch Integration by adding to the EnemyQueue random EnemyProfiles at random times
 - There can only be one enemy alive or in the queue at a time.  This logic is handled by the EnemyQueuePermissions
 
 Twitch Integration
 - To enable twitch integration, download the TwitchWorks plugin & follow the instructions to enable it
 - In EnemySpawnerGameMode, turn on the twitch integration boolean
 - Please when making changes turn off the twitch integration and use the random enemy spawner instead, twitch integration should only be turned on for publishing
