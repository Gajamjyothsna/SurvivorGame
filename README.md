# SurvivorGame
This is 3D Survivor Game developed in Unity and c#.

## **Gameplay Mechanics**
### **Player Character**
- The player character can move forward, backward, left, and right using Virtual joystick controls.
- The player character will have a health bar that will decrease when attacked by enemies.
- The player character will have a fixed radius around them (x units), which will serve as a defensive zone.
- When enemies enter the player&#39;s radius, the player character will shoot bullets, causing the enemies to decrease in health and be defeated.
- The player character can collect coins dropped by defeated enemies.

### **Enemies**
- Enemies will spawn at random positions in the game world.
- There will be two types of enemies:
a. Type 1: These enemies will move towards the player character aggressively.
b. Type 2: These enemies will spawn at random positions and will not move and they will attack enemies by throwing bullets or something from a distance.
- Both enemy types will have health bars that decrease when hit by the player character’s bullet.
- When an enemy&#39;s health bar reaches zero, they will drop coins and the enemies will disappear from the gameplay screen.

### **Coins**
- Coins will be dropped by defeated enemies.
- The player character can collect coins to earn points or currency for in-game upgrades.

Gameplay Flow:
1. The game starts with the player character in the center of the screen.
2. Enemies will start spawning at random positions and move towards the player character or project attacks.
3. If an enemy enters the player character&#39;s radius, they will be defeated with bullets projected by the player character.
4. The player character can attack enemies by shooting projectiles.
5. Enemies will take damage when hit by the player&#39;s attacks.
6. When an enemy&#39;s health bar reaches zero, they will drop coins, which the player can collect.
7. The player character&#39;s health bar will decrease when hit by enemy attacks.
8. The game continues until the player character&#39;s health bar is empty.
9. The player&#39;s performance is measured based on the number of enemies defeated and the number of coins collected.

### **Design Patterns**
- Object Pooling
- Singleton
