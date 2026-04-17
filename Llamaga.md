# Llamaga v0.1 – Basic Mouse-Controlled Galaga Clone

**Project Name:** Llamaga  
**Version:** 0.1 (Minimal Viable Clone)  
**Date:** April 17, 2026  
**Description:** A clean, faithful vertical space shooter inspired by classic Galaga, controlled exclusively with mouse input. Focuses on core arcade loop: formation-based enemies, diving attacks, precise shooting, and incremental wave progression. Designed for easy iteration into richer enemy variety and attack patterns.

## Core Boundaries (Delineation)

### Inside Scope (v0.2)
- Vertical fixed-screen space shooter (no background scrolling initially)
- Mouse-only controls for movement and firing
- Single player ship at bottom of screen
- Enemy formation at top that breaks into diving attacks
- Basic projectile combat (player upward, enemies downward)
- Simple collision detection and scoring
- Lives system (3 lives)
- Incremental wave progression with increasing difficulty
- Whimsical graphics theme (flying llama player, chicken/turkey enemies)
- Dynamic starfield background with wave-completion warp effect
- Comprehensive sound FX set for selection and implementation
- Built in Pygame for rapid prototyping and execution

### Outside Scope (Deferred to Future Versions)
- Tractor beam / enemy capture mechanics
- Dual-ship power-ups or multi-ship control
- Boss enemies or mid-wave special encounters
- Advanced particle effects or explosions (beyond basic starfield)
- High-score persistence / save system
- Complex enemy pathing (full loops, sine waves, etc.)

### Core Constraints
- Mouse X controls horizontal ship movement only (Y fixed near bottom)
- No keyboard movement support
- Maximum 2 player bullets on screen simultaneously (classic limit)
- Sprite size fixed at 32×32 pixels
- Screen resolution recommendation: 800×600 (adjustable)

## Game Concept (Waist)

A pure arcade-style vertical shooter. The player defends the bottom of the screen against waves of enemies attacking from a formation at the top. Enemies periodically break formation to dive toward the player while firing. The objective is to clear each wave by destroying all enemies before they reach the bottom or destroy the player. Waves automatically advance with slight increases in speed, count, or aggressiveness. The game emphasizes precise mouse aiming, dodging, and timing, now enhanced with a fun, whimsical visual and audio theme.

## Player Mechanics (Leg 1)

- **Ship:**
  - Positioned near the bottom of the screen
  - Visual: 32×32 flying llama sprite
  - Starts centered, can move left/right only

- **Movement:**
  - Mouse X-position directly maps to ship horizontal position
  - Smooth movement with edge clamping (cannot leave screen)

- **Firing:**
  - Left mouse click fires a single upward projectile
  - Optional: Hold-to-auto-fire with rate-of-fire cooldown
  - Maximum 2 player bullets active at once
  - Bullets move upward at constant speed

- **Stats:**
  - Lives: 3 (lose one on hit by enemy bullet, enemy collision, or enemy reaching bottom)
  - Score: Starts at 0, increases with enemy destructions (different rows worth different points)

## Enemies, Waves & Core Loop (Leg 2)

- **Enemy Formation:**
  - Grid layout: 4–6 rows × 8–10 columns at top of screen
  - Initially static formation
  - Different rows can have different point values and slight visual distinction (chickens and turkeys)

- **Attack Behavior (Basic v0.2):**
  - Most enemies remain in formation
  - Periodically, 1–3 enemies break formation and dive toward the player
  - Dive paths: Straight downward or gentle arc (expandable later)
  - Diving enemies can fire downward projectiles
  - Destroyed or completed-dive enemies are removed

- **Enemy Projectiles:**
  - Move downward at moderate speed
  - Fired by diving enemies or periodically from formation

- **Collisions:**
  - Player bullet hits enemy → enemy destroyed + points awarded
  - Enemy bullet hits player → lose 1 life
  - Enemy reaches bottom of screen → lose 1 life
  - Enemy collides with player → lose 1 life

- **Wave System:**
  - Wave clears when all enemies in the formation are destroyed
  - Brief pause between waves
  - Each subsequent wave increases difficulty incrementally:
    - More enemies
    - Faster movement and dive speed
    - Slightly more frequent or aggressive dives
    - Gentle increase in dive path curvature (future-proof)

- **Game States:**
  - Playing
  - Between waves (short pause)
  - Game Over (lives = 0)
  - Optional: Simple restart on game over

## UI Elements
- Score displayed top-left
- Lives (icons or text) top-right
- Current Wave number near top-center
- Game Over screen with final score and restart prompt

## Graphics and Sound FX

## Graphics and Sound FX
- Use visualfx skill and soundfx skill to generate.
- Moving star background that implies forward motion through each wave. Completing a wave invokes a warping effect which gradually engages over a span of 3 seconds, stretching the star field and then hiding the star field after it stretches the start tracks to the length of the screen.
- Sprite size 32x32, with animated turning/banking while the sprite is changing course.
- Player sprite is a flying llama, enemies are chickens and turkeys.
- create a variety of sound fx for me to select from representing player main weapon firing, alt weapon firing, enemies hit by player fire, player hit by enemy fire, powerups, various enemy firing features and skill activations, and for level activation and level completion.

- Use **visualfx skill** and **soundfx skill** to generate all assets.
- **Sprite size:** Fixed at 32×32 pixels for all game objects, with animated turning/banking while the sprite is changing course.
- **Player sprite:** Flying llama (animated if possible within skill constraints).
- **Enemy sprites:** Chickens and turkeys (variety across rows; animated if possible).
- **Background:**
  - Moving starfield that implies forward motion through each wave.
  - On wave completion: warping effect gradually engages over a span of 3 seconds — stretching the star field and then hiding the starfield after it stretches the star tracks to the length of the screen.
- **Sound FX (variety to be generated for selection):**
  - Player main weapon firing
  - Alt weapon firing (future-proof placeholder)
  - Enemies hit by player fire
  - Player hit by enemy fire
  - Powerups (future-proof placeholder)
  - Various enemy firing features
  - Skill activations (future-proof placeholder)
  - Level activation (wave start)
  - Level completion (wave clear)

## Technical Architecture (Pygame Skeleton Ready)

- **Main Classes:**
  - `Player`: Handles mouse movement, shooting, lives, drawing
  - `Bullet`: Base class for player and enemy projectiles (with direction)
  - `Enemy`: Position in formation, dive state, simple AI, drawing
  - `GameManager` / `WaveManager`: Formation layout, wave progression, scoring, collision handling, game state, starfield + warp logic
  - `VisualFX` / `SoundFX` handlers (to be implemented via designated skills)

- **Recommended Structure:**
  - Sprite groups for efficient updates and collisions
  - Clean main loop: event handling → updates → collisions → drawing
  - Modular design to allow easy addition of new enemy behaviors later

## Next Steps (Planner Path)

1. Lock this v0.2 specification as baseline
2. Generate runnable Pygame prototype code (basic ship + mouse movement + shooting + placeholder enemies + starfield)
3. Activate **visualfx skill** and **soundfx skill** to produce 32×32 llama / chicken / turkey sprites and full sound FX set
4. Test core loop + graphics/sound integration in controlled environment
5. Iterate: Add full enemy formation → diving attacks → wave system → difficulty ramp → warp transition

**Version History**  
- v0.1 (April 17, 2026): Initial clean clone specification  
- v0.2 (April 17, 2026): Graphics & Sound FX layer added (llama/chicken/turkey theme, starfield warp, SFX list)

**Living Document Note**  
This file serves as the stable anchor for all future development. Any changes or expansions will be versioned and referenced back to this core without breaking the fundamental Galaga-style loop.
