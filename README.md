# pearl-diver
project is created with unity version: 2021.3.23f1
functionalities:

Diver:
- moving diver in x and y directions with key arrows
- diver is limited to the field of the camera
- velocity accelerates
- diver has no gravity enemies have gravity (except some in level 3 have a frozen y coordinate)
- diver can change states (red and green) and is able to shoot when in red state
- diver only dies in green state, in red state he goes back to green
- diver changes direction if he goes to the right/left or up an down
- diver can enter pipes and is now underground
- animations for hitting a mystery block
- check if diver hits block from below it
- reloading scene you ae currently in if you loose a live
Enemies:
- different enemies with diffrent behavior
- turtles can go into their shell if they are hit with a bullte. Shell can also move if being pushed and chamges direction when hitting e.g. pipes.
- if turtle is in shell in can hit the diver or the jelly
- eniemies stop moving if they are not in frame or entities get detsroyed
All entities:
- animations of all moving entities
- death animations for entities (sometimes also death sprites for e.g. diver and jelly)
Other:
- selfmade sprites
- clicking buttons in menu
- live status of lives and pearls
- camera can only go right
- load new level when diver hits pearl in seashell castle

Problems I came across:
It took me some time to figure out that I need to make the canvases a child of the GameSceneManager in order to not get them destroyed at the next level or any other load.
The underground part was tricky because there were a lot of adjustments to be made and complications were occurring e.g. the player being stuck in weird places. This could be solved by adjusting the x and y coordinates of the camera and another transform point in an unoccupied place in the scene.


The process of creating my project is chronologically described in the following. (Instead of commits)

I started my project by designing and drawing all of the sprites. Then I set up the first scene.
After that, I created all the corresponding prefabs, added colliders, sprite renders, different layers, tags, etc., and set the camera according to my GameScene.
In the next step, I started with the player, the diver. I created the prefab and a player movement script. I set the movement in the x and y directions, typical for a diver. Because of that, the gravity is off. 
Furthermore, I limited the divers movement to the camera frame (to the top and left side of the frame). The camera moves with the diver because of the camera movement script.
To check for different kinds of collision I created the Extension Script, so I can use the Raycast function multiple times. 
To make movements over blocks smoother I added a no-friction script. 
A sprite animation renderer script for the player was added to make the divers movement more realistic. 
A Game Manager was added to manage the state of lives and pearls of the diver. It also manages the reset of a level and the loading of a new one.
Moreover, enemies were added to the scene and each of them has a specific script for specific behavior. Another script was added to manage the moving of other entities because they have gravity and the diver does not.
Another script was created to animate the movement of the enemies (Sprite Animation).
Enemies and the diver can die. That is why I have also added the death script to animate and manage their death.
Since the diver has different states these need to be tracked as well. For this, the Player script comes in handy.
Another script was added to account for the death of all entities if they cross a certain point (Point of death).
In the next step, hitting blocks and power-ups were added. I added the HitBlocks and Items scripts to animate the block and the item “popping” out of it. After that, different powerups were defined in the pearl script and the PowerUp script. I distinguish between the collector pearls in the scene and the pearls popping out of a block (Pearls).
Now, the red diver can be activated. In the following, I added the bulletMove for the bullets and added code to the player movement script to make the diver shoot when he is in his red state.
Moreover, I added pipes and a script for pipe entering. In order to do that the camera also had to be adjusted. 
There was also a script added NextLevel to attach it to the Seashell Castle to change into the next level.
After the gameplay parts, I started to work on the UI manager. 
I added text to show lives and pearls (UiManager).
Finally, I added multiple scenes. I started with the creation of a starting scene with the usage of buttons to click to rules or start the game (Script: Buttons). After that, I created a GameOver scene, two new levels, and finally, a winning scene after you complete the last level.
