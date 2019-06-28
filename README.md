# LevelUpLarry2DSS
Larry is travelling through a 2D side scrolling environment when he is confronted by a horde of creatures ( zombies, medieval army, wild animals? ).  

Based off [Design doc](https://docs.google.com/document/d/1iMpK-hJsFLI4GPMWzvPedDiAtvYZl5U48OwvbeyLm2I/edit#heading=h.19u0nz2irg77) on Google Docs.  This project is the `Larry vs Twitch Chat` idea.

In order to use this project, you must use UE4 v4.21.2

Right now this is still a prototype and currently in development.

The next phases to get to a Proof of Concept are:
 - Enemy spawning system - queues up enemies off screen that will be spawned as larry progresses through the level
 - Procedurally generated infinite scrolling level
 - Hook up twitch chat integration
 
Polish
 - Don't move camera until Larry gets to X percentage of the screen in either direction, so he can run back and forth without moving the camera.  
 - Once the camera doesn't move all the time with simple movement, adjust spawning system to pause spawns if camera isn't moving instead of character
