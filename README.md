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
## Scene Flow 

```mermaid
flowchart LR
  mm[Main Menu]
  gp[Gameplay]
  es[End Screen]

  mm -- "Click Play" --> gp
  gp -- "Player Dies / Level Complete" --> es
  es -- "Restart" --> gp
  es -- "Main Menu" --> mm

```
## Layer / module Design 

```mermaid
---
config:
  theme: neutral
  look: neo
---
graph TD
    subgraph "Game Initialization"
        Start([Game Start])
        Boot[Boot Layer]
    end
    subgraph "Main Menu"
        MM[Main Menu]
    end
    subgraph "Gameplay Flow"
        GP[Gameplay Scene]
        Player[Player Controller]
        Level[Level Manager]
        Obstacle[Obstacle System]
        UI[UI Manager]
    end
    subgraph "End States"
        ES[End Screen]
    end

    %% Flow connections
    Start --> Boot
    Boot --> MM
    MM -->|Play| GP
    GP --> Player
    GP --> Level
    GP --> Obstacle
    GP --> UI
    GP -->|Death / Goal Reached| ES
    ES -->|Restart| GP
    ES -->|Main Menu| MM

    %% Style definitions
    classDef initStyle fill:#e1f5fe,stroke:#01579b,stroke-width:2px
    classDef menuStyle fill:#f3e5f5,stroke:#4a148c,stroke-width:2px
    classDef gameplayStyle fill:#e8f5e8,stroke:#1b5e20,stroke-width:2px
    classDef endStyle fill:#ffebee,stroke:#b71c1c,stroke-width:2px

    %% Apply styles
    class Start,Boot initStyle
    class MM menuStyle
    class GP,Player,Level,Obstacle,UI gameplayStyle
    class ES endStyle

```

<br>
## Module and Features

| 📂 Name              | 🎬 Scene                  | 📋 Responsibility                                                                                                      |
| -------------------- | ------------------------- | ---------------------------------------------------------------------------------------------------------------------- |
| **MainMenu**         | **Main Menu**             | - Display UI<br/>- Start game or exit                                                                                  |
| **PlayerController** | **Gameplay**              | - Handle horizontal movement and jumping<br/>- Detect collisions with environment<br/>- Manage respawn and checkpoints |
| **LevelManager**     | **Gameplay**              | - Manage level start and completion<br/>- Handle transitions and reset                                                 |
| **ObstacleSystem**   | **Gameplay**              | - Detect traps and hazards<br/>- Trigger player death or respawn                                                       |
| **UIManager**        | **Gameplay / End Screen** | - Show player status, score, and level completion<br/>- Handle restart and menu navigation                             |
| **GameOver**         | **End Screen**            | - Display end state (Win/Lose)<br/>- Restart or return to main menu                                                    |

<br>

```mermaid
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
  complete --> next[Next Level or End Screen]
  next --> move


```

<br>

```mermaid
classDiagram
    %% --- Core Gameplay ---
    class PlayerController {
        +OnMoveHorizontal()
        +OnJump()
        +OnLand()
        +OnRespawn()
        +OnCollectItem(itemName: string)
    }

    class LevelManager {
        +OnLevelStart(levelName: string)
        +OnCheckpointReached()
        +OnLevelComplete()
    }

    class ObstacleSystem {
        +OnPlayerHit()
        +OnHazardTriggered()
    }

    class UIManager {
        +OnUpdateHealth(value: int)
        +OnShowGameOver()
        +OnShowLevelComplete()
    }

    %% --- Systems ---
    class GameManager {
        +OnGameStart()
        +OnPlayerDeath()
        +OnRestartLevel()
    }

    class AudioManager {
        +OnPlaySFX(effectName: string)
        +OnPlayBGM(trackName: string)
    }

    %% --- Relations (who triggers what) ---
    PlayerController --> LevelManager : triggers progression
    PlayerController --> ObstacleSystem : interacts with
    ObstacleSystem --> GameManager : notifies death
    LevelManager --> UIManager : updates UI state
    GameManager --> AudioManager : plays sound events
    GameManager --> UIManager : controls end screen

'''
