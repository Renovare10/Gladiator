# Gladiator Game Summary and File Overview

## Game Summary
**Gladiator** is a text-based C# auto-battler where you play as a gladiator agent/coach aiming to win the Rome Gladiator Cup. You manage a team of gladiators that automatically fight enemy teams in turn-based combat. Victory is achieved by defeating all enemies in a battle, with the ultimate goal of winning the cup through multiple battles. Defeat occurs if your entire team dies. The game currently features 1v1 auto-combat with randomized damage, setting the stage for future features like larger teams, gold rewards, weapon/armor upgrades, and item shops.

**Current State**: The game supports a single hero (100 HP, Fist weapon) vs. a goblin (30 HP, Fist weapon) in an auto-battle loop. Combat uses an observer pattern for attack/death events, displayed via console. Each attack deals random damage (1-3 for Fist). The game ends when one team is defeated, with win/lose feedback.

**Next Steps**: Add a second weapon (e.g., Knife), expand to multi-character teams (e.g., 2v2), introduce gold rewards, and add player choice (e.g., weapon switching).

## File Overview
- **Program.cs**:  
  Entry point. Initializes a `TeamManager` with 1v1 teams (hero vs. goblin), subscribes to attack/death events for console output, and runs the auto-battle loop until one team dies. Prompts user to press Enter per round and displays win/lose status.

- **TeamManager.cs**:  
  Manages two teams (`PlayerTeam`, `EnemyTeam`) as `List<Character>`. Runs auto-battle rounds where each living character attacks a random living opponent. Returns false when a team is fully defeated, ending the battle. Scalable for multi-character teams.

- **Character.cs**:  
  Represents a gladiator with `Health`, `Alive` status, and a `Weapon` (`IWeapon`). Handles attacks (`Attact`) with random damage and damage-taking (`Damage`). Fires `OnAttack` and `OnDeath` events for UI/logging. No direct console output for clean separation.

- **Helper.cs**:  
  Static utility for UI. `PrintStatus` shows both teams’ health and alive/dead status. `PrintAttack` and `PrintDeath` handle event-driven console output for attacks and deaths, keeping UI logic centralized.

- **IWeapon.cs**:  
  Interface for weapons with `Name`, `DamageRange` (min-max), and `GetRandomDamage` (default implementation returns random damage in range). Currently used by `Fist`.

- **Fist.cs**:  
  Implements `IWeapon` for the Fist weapon. Has a `DamageRange` of 1-3 and a name ("Fist"). Relies on `IWeapon`’s default `GetRandomDamage`.

- **DamageRange.cs**:  
  Struct defining a damage range (`Min`, `Max`) with validation to ensure `Min <= Max`. Used by `IWeapon` to support randomized damage.

## Goals
- **Short-Term**: Add a second weapon (e.g., Knife, 4-6 damage), enable weapon switching, and expand to 2v2 teams.
- **Long-Term**: Implement gold rewards, armor, item shop, and multi-battle progression toward the Rome Gladiator Cup. Enhance interactivity (e.g., team composition, targeting).

## How to Run
Run `Program.cs` in a C# environment. Press Enter to advance each round, observe attack/death messages, and see the final win/lose outcome. Check console output for team status and combat events.