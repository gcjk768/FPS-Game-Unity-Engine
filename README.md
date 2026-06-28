# 🎮 FPS-Game-Unity-Engine

[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity%202022.3%20LTS-000000?style=flat-square&logo=unity&logoColor=white)](https://unity.com/)
[![Language: C#](https://img.shields.io/badge/Language-C%23-512BD4?style=flat-square&logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![License: MIT](https://img.shields.io/badge/License-MIT-39D353?style=flat-square)](LICENSE)

A first-person shooter prototype built in **Unity** with **C#** — featuring first-person movement, a multi-weapon combat system with pickups, destructible/shootable targets, grenades and explosions, and a stylized low-poly arena.

> Built as a hands-on project to learn Unity's component model, physics, raycasting and input handling.

---

## ✨ Features

- **First-person controller** — WASD movement with mouse look (`FPSInput.cs`, `MouseLook.cs`)
- **Weapon arsenal** — Pistol / M1911, Machine Gun, Shotgun, Grenade launcher and a physics **Ball Launcher**
- **Weapon pickups** — walk over a pickup to unlock and switch weapons (`*_WeaponPickup.cs`, `activate*.cs`)
- **Shooting & hit detection** — raycast/projectile fire against `Shootable` targets
- **Grenades & explosions** — timed grenades with radial `Explosion` force and damage
- **Flashlight** — toggleable light for the darker areas of the map (`Flashlight.cs`)
- **Respawn logic** — `RespawnCube` resets the player/objects when they fall out of bounds
- **Stylized environment** — low-poly weapon pack + stylized lava materials, TextMeshPro HUD

## 🕹️ Controls

| Action | Input |
| --- | --- |
| Move | `W` `A` `S` `D` |
| Look | Mouse |
| Fire | Left Mouse Button |
| Switch weapon | Walk over a weapon pickup |
| Toggle flashlight | `F` |
| Throw grenade | Equip grenade, then fire |

> Exact bindings are defined in the input scripts — adjust them in the Unity Editor as needed.

## 🚀 Getting Started

### Prerequisites
- [Unity **2022.3.4f1** (LTS)](https://unity.com/releases/editor/archive) or newer 2022.3.x
- Unity Hub

### Run it
```bash
git clone https://github.com/gcjk768/FPS-Game-Unity-Engine.git
```
1. Open **Unity Hub → Add → Add project from disk** and select the `My project` folder.
2. Open the project with Unity **2022.3.x**.
3. In the Project window, open `Assets/Scenes/FPS.unity`.
4. Press **▶ Play**.

## 🗂️ Project Structure

```
My project/
├── Assets/
│   ├── Script/                  # All C# gameplay scripts
│   ├── Scenes/FPS.unity         # Main playable scene
│   ├── Prefabs/                 # Weapons, pickups, projectiles
│   ├── Materials/               # Materials & stylized lava
│   └── Low Poly Weapons VOL.1/  # Weapon art pack
└── ProjectSettings/             # Unity project configuration
```

## 🛠️ Built With

- **Unity 2022.3 LTS** — engine, physics, lighting
- **C#** — gameplay scripting
- **TextMeshPro** — in-game UI / HUD

## 📄 License

Released under the [MIT License](LICENSE) — © 2026 James Koh.
