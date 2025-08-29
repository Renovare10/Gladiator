# Gladiator Game Summary and File Overview

## Game Summary
**Gladiator** is a text-based C# auto-battler where you play as a gladiator agent/coach aiming to win the Rome Gladiator Cup. You manage a team of gladiators (currently one, named "Gladius") that automatically fight enemy teams (e.g., "Goblin") in turn-based combat. Victory is achieved by defeating all enemies, earning 10 gold per win, with the ultimate goal of winning the cup through multiple battles. Defeat occurs if your team dies. The game features 1v1 auto-combat with randomized damage (Fist: 1-3) and an event-driven system for attacks, deaths, and rewards.

**Current State**: A single hero ("Gladius", 100 HP, Fist) battles a goblin ("Goblin", 30 HP, Fist). Combat uses `IWeaponStrategy` to pick the highest-damage weapon (currently only Fist). `TeamManager` runs rounds, firing `OnAttack` and `OnDeath` events for UI and `OnBattleWon` for gold rewards (via `GameState`). Gold displays in the console, enhancing progression.

**Next Steps**: Add a second weapon (e.g., Knife), expand to 2v2 teams, enable gold spending (e.g., healing, weapons), or add optional naming prompts for player choice.

## File Overview
- **Program.cs**:  
  Entry point. Initializes `TeamManager` (1v1: Gladius vs. Goblin), `GameState` for gold, and subscribes to events for console output. Runs the auto-battle loop, displaying names, gold, and win/lose status.

- **TeamManager.cs**:  
  Manages teams (`PlayerTeam`, `EnemyTeam`) and auto-battle rounds. Fires `OnBattleWon` when the player wins, triggering gold rewards. Scalable for multi-character teams.

- **GameState.cs**:  
  Tracks `PlayerGold`, subscribes to `OnBattleWon` to award 10 gold per win. Decouples reward logic for future scalability (e.g., items, armor).

- **Character.cs**:  
  Represents a gladiator with `Name`, `Health`, `Inventory`, and `IWeaponStrategy`. Handles attacks (`Attact`) with random damage and fires `OnAttack`/`OnDeath` events. Uses `GetCurrentWeapon` for UI.

- **Helper.cs**:  
  Static utility for UI. `PrintStatus` shows team names, health, weapons, and gold. `PrintAttack` and `PrintDeath` handle event-driven output, keeping UI centralized.

- **IWeapon.cs**:  
  Interface for weapons with `Name`, `DamageRange`, and `GetRandomDamage` (default implementation). Used by `Fist`.

- **Fist.cs**:  
  Implements `IWeapon` for Fist (1-3 damage range, name: "Fist"). Relies on `IWeapon`’s `GetRandomDamage`.

- **DamageRange.cs**:  
  Struct defining a damage range (`Min`, `Max`) with validation. Used by `IWeapon`.

- **IWeaponStrategy.cs**:  
  Interface for weapon selection strategies (e.g., pick highest damage). Defines `SelectWeapon` and `OnInventoryChanged`.

- **HighestDamageStrategy.cs**:  
  Implements `IWeaponStrategy`, caching the weapon with highest `DamageRange.Max` for efficiency.

## Goals
- **Short-Term**: Add a second weapon (e.g., Knife), expand to 2v2 teams, enable gold spending (e.g., healing).
- **Long-Term**: Implement optional naming prompts, multi-battle progression, and item shops for the Rome Gladiator Cup.

## How to Run
Run `Program.cs` in a C# environment. Press Enter to advance rounds, observe attack/death messages, gold (10 on win), and win/lose outcome. Check console for team names (Gladius, Goblin) and gold.