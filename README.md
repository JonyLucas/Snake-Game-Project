# Snake Game Project
A Snake game, where the player have a block to pick and an enemy AI snake to dispute that block. Both the block and the enemy snake respawn when they are picked or dead, as long as the player is alive.
When a block is picked by a snake, it is added to the snake body, becoming its head. Multiple blocks can be picked at once if they are inline in the same direction of the snake's movement.

### Movement
The movement is relative to the direction the snake is moving -- i.e., pressing left makes the snake turn 90 degrees to its left -- and the snake can't go straight back in one turn, must make two turns in the same direction.

### Multiplayer
The game have a local multiplayer for two players, where each player controls a snake.

### Powerups [WIP]
The player can collect specials objects that provides temporary invulnerability and the ability to reset position when the player dies, giving an extra life for the player.

Post Processing
-----
If you want to use the game with Post Processing, you should switch to the PostProcessing branch.
Here's a video of the game with Post Processing.

https://user-images.githubusercontent.com/19211058/143838839-1dcdfdcf-b733-49fb-8471-bc2870f11d66.mp4


Game Demo
-----
SinglePlayer

https://user-images.githubusercontent.com/19211058/143821095-16d37ebe-6035-4bb7-98e2-e8271926ab6f.mp4


Multiplayer

https://user-images.githubusercontent.com/19211058/143821243-59877b1c-99c5-4373-86d9-3636a8065065.mp4

Arquitetural diagram
-----
![Diagrama de arquitetura](https://user-images.githubusercontent.com/19211058/143820193-00c38b45-cd49-4c15-9f4b-57ada99735ac.png)


The sprites
-----
the snakes

![Entire Snake](https://user-images.githubusercontent.com/19211058/143821824-91ccde40-c40f-44b1-9aad-fceaf9f13dc5.png)


the collectables

![Food - MD](https://user-images.githubusercontent.com/19211058/143822380-4744a524-35a3-4402-a63f-3eaf315cbaee.png)
![Reset Position - MD](https://user-images.githubusercontent.com/19211058/143822398-93d5ae91-71c4-4d32-83b9-9b33c2d86862.png)
![Shield Collectable - MD](https://user-images.githubusercontent.com/19211058/143822403-4e89e5ef-0e11-45fa-9060-879d09af0339.png)

