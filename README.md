# stealth_game3d
```
This is test task for company
A simple prototype of the game with stealth mechanics.
There is a player, enemy, obstacle
```
## Enemy logic
##### Patrol
```
The enemy patrols the territory by points in the center of the map.
When the enemy sees the player, the hunt begins.
```
##### Hunt
```
The enemy is running after the player while he sees him.
If the enemy not sees the player more,
he checks the last location where he saw the player, if he is not there, he returns to patrol
```
