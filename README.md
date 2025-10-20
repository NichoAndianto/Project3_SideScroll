Developer & Contributions

NichoAndianto (Game Developer)
<br>

About

Side-Scrolling Platformer [Prototype] is a 2D action platformer project developed to explore character movement, obstacle interaction, and progressive level design. The game focuses on smooth player control, responsive jumping, and engaging level flow. My contributions include designing the movement system, implementing physics-based interactions, and developing the level progression framework.

<br>

Key Features

Responsive Controls: Smooth horizontal movement, jumping, and mid-air adjustments.

Obstacle Interaction: Collision-based physics for traps, platforms, and collectibles.

Level Progression: Structured stages with checkpoints and end-goals.

Simple Aesthetic: Clean visual design emphasizing clarity and flow.

<br>
Scene Flow

flowchart LR
  mm[Main Menu]
  gp[Gameplay]
  es[End Screen]

  mm -- "Play" --> gp
  gp -- "Player Death / Level Complete" --> es
  es -- "Restart" --> gp
  es -- "Main Menu" --> mm
  
<br>

| 📂 Name              | 🎬 Scene                  | 📋 Responsibility                                                                                                      |
| -------------------- | ------------------------- | ---------------------------------------------------------------------------------------------------------------------- |
| **MainMenu**         | **Main Menu**             | - Display UI<br/>- Start game or exit                                                                                  |
| **PlayerController** | **Gameplay**              | - Handle horizontal movement and jumping<br/>- Detect collisions with environment<br/>- Manage respawn and checkpoints |
| **LevelManager**     | **Gameplay**              | - Manage level start and completion<br/>- Handle transitions and reset                                                 |
| **ObstacleSystem**   | **Gameplay**              | - Detect traps and hazards<br/>- Trigger player death or respawn                                                       |
| **UIManager**        | **Gameplay / End Screen** | - Show player status, score, and level completion<br/>- Handle restart and menu navigation                             |
| **GameOver**         | **End Screen**            | - Display end state (Win/Lose)<br/>- Restart or return to main menu                                                    |

<br>
GameFlow

flowchart TD
  start([Game Start])
  start --> move[Player Movement]
  move --> jump{Jump Input?}
  jump -->|Yes| applyJump[Apply Jump Force]
  jump -->|No| gravity[Apply Gravity]
  applyJump --> gravity
  gravity --> collide{Collision?}
  collide -->|Ground| resetJump[Reset Jump State] --> move
  collide -->|Hazard| respawn[Respawn Player] --> move
  collide -->|Goal| complete[Level Complete]
  complete --> nextLevel[Next Level or End Screen]
  nextLevel --> end([Game End])

<br>
