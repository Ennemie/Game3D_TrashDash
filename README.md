# Trash Dash

### 🎮 3D Endless Runner Game

> **Trash Dash** là một game 3D endless runner được phát triển bằng **Unity**, trong đó người chơi điều khiển nhân vật vượt qua môi trường liên tục thay đổi, né chướng ngại vật và thu thập vật phẩm để đạt điểm số cao nhất.

<p align="center">
  <img src="https://img.shields.io/badge/Unity-6000.2.10f1-black?style=for-the-badge&logo=unity" alt="Unity">
  <img src="https://img.shields.io/badge/C%23-Game%20Development-239120?style=for-the-badge&logo=csharp" alt="C#">
  <img src="https://img.shields.io/badge/URP-Unity-000000?style=for-the-badge&logo=unity" alt="URP">
  <img src="https://img.shields.io/badge/WebGL-Playable%20Build-orange?style=for-the-badge" alt="WebGL">
  <img src="https://img.shields.io/badge/Windows-Playable%20Build-blue?style=for-the-badge&logo=windows" alt="Windows">
</p>

---

## 🎬 Gameplay Preview

<p align="center">
  <img src="docs/images/gameplay.gif" width="850" alt="Trash Dash Gameplay">
</p>

> 🚧 Thêm GIF gameplay vào `docs/images/gameplay.gif` để hiển thị preview tại đây.

---

# 🕹️ About The Game

**Trash Dash** là một game 3D endless runner được xây dựng với Unity.

Gameplay tập trung vào:

* 🏃 Di chuyển liên tục
* 🧱 Né chướng ngại vật
* 🦴 Thu thập vật phẩm
* 🗺️ Môi trường có chuyển động
* 💡 Các hiệu ứng ánh sáng
* 🎥 Camera & gameplay presentation
* 🎮 Điều khiển bằng Unity Input System

Project được tổ chức thành các hệ thống riêng cho **Game Manager**, **Player** và **UI**.

---

# ✨ Features

### 🏃 Endless Runner Gameplay

Người chơi phải liên tục di chuyển trong môi trường game và phản ứng nhanh với những thử thách xuất hiện phía trước.

### 🦴 Collectibles

Game có hệ thống vật phẩm với `FishBoneController`, phục vụ cho gameplay/collectible interaction.

### 🐶 Player Controller

Project có hệ thống player riêng được tổ chức trong:

```text
Assets/Scripts/Player/
```

giúp tách logic điều khiển nhân vật khỏi các hệ thống gameplay khác.

### 🗺️ Moving Environment

`MovingMap.cs` được sử dụng cho hệ thống môi trường chuyển động, phù hợp với gameplay endless runner.

### ⚡ Dynamic Effects

Project có các component riêng cho hiệu ứng gameplay:

```text
LightningFlash.cs
SpotlightController.cs
```

giúp xây dựng các hiệu ứng ánh sáng và presentation trong game.

### 🎥 Camera & Presentation

Project sử dụng **Cinemachine 3.1.5** cho camera system.

---

# 🎮 Gameplay

```text
                 START
                   │
                   ▼
            ┌─────────────┐
            │    RUN      │
            └──────┬──────┘
                   │
                   ▼
          ┌─────────────────┐
          │  Avoid Objects  │
          └────────┬────────┘
                   │
          ┌────────┴────────┐
          ▼                 ▼
      🦴 Collect          💥 Hit
          │                 │
          ▼                 ▼
      Score / Game        Game Over
       Progress              │
          │                 │
          └────────┬────────┘
                   ▼
                Restart
```

---

# 🛠️ Tech Stack

| Technology              | Purpose              |
| ----------------------- | -------------------- |
| 🎮 **Unity 6**          | Game Engine          |
| 💻 **C#**               | Gameplay Programming |
| 🎥 **Cinemachine**      | Camera System        |
| 🎛️ **Input System**    | Player Input         |
| 🧭 **AI Navigation**    | Navigation Support   |
| 🎨 **URP**              | Rendering            |
| 📦 **Addressables**     | Asset Management     |
| 🛒 **Unity Purchasing** | Purchasing System    |
| 🎞️ **Timeline**        | Cinematic / Sequence |
| 🧩 **Visual Scripting** | Visual Logic         |

Project hiện được cấu hình với **Unity 6000.2.10f1**.

Các package quan trọng trong project bao gồm Addressables 2.7.4, AI Navigation 2.0.9, Cinemachine 3.1.5, Input System 1.14.2, URP 17.2.0, Purchasing 4.12.2 và Timeline 1.8.9.

---

# 🧠 Game Architecture

Project chia gameplay code thành ba nhóm chính:

```text
Assets/
└── Scripts/
    │
    ├── GameManager/
    │   ├── GameManager.cs
    │   ├── DogController.cs
    │   ├── FishBoneController.cs
    │   ├── MovingMap.cs
    │   ├── LightningFlash.cs
    │   ├── SpotlightController.cs
    │   └── SettingData.cs
    │
    ├── Player/
    │   └── Player Systems
    │
    └── UI/
        └── UI Systems
```

Cách tổ chức này giúp gameplay manager, player logic và UI được tách thành các module riêng biệt.

---

# 📂 Project Structure

```text
Game3D_TrashDash/
│
├── Assets/
│   ├── Animation/
│   ├── Bundles/
│   ├── Materials/
│   ├── Models/
│   ├── Prefabs/
│   ├── Resources/
│   ├── Scenes/
│   │   ├── Intro.unity
│   │   ├── GamePlay.unity
│   │   ├── GamePlay_Profiles/
│   │   └── Start/
│   │
│   ├── Scripts/
│   │   ├── GameManager/
│   │   ├── Player/
│   │   └── UI/
│   │
│   ├── Shaders/
│   ├── Sounds/
│   ├── TextMesh Pro/
│   ├── Textures/
│   └── UI/
│
├── Packages/
│
├── ProjectSettings/
│
├── WebGLBuild/
│
├── WindowsBuild/
│
├── WebGLBuild.zip
│
└── README.md
```

Repository hiện có riêng `WebGLBuild`, `WindowsBuild` và `WebGLBuild.zip`, vì vậy project không chỉ chứa source Unity mà còn có build output để phân phối/chạy thử.

---

# ▶️ Play The Game

## 🌐 WebGL

Project có sẵn thư mục:

```text
WebGLBuild/
```

Nếu build WebGL đã được publish lên hosting, có thể thêm link:

```text
🎮 Play in Browser
https://your-webgl-link.com
```

> 💡 Đây nên là phần nổi bật nhất của README nếu bạn có link WebGL online.

---

## 🪟 Windows

Project cũng có:

```text
WindowsBuild/
```

Bạn có thể tải Windows build từ GitHub hoặc Releases.

---

# 🚀 Open The Project

## Requirements

* **Unity 6000.2.10f1**
* Git
* Unity-compatible IDE

## Clone

```bash
git clone https://github.com/Ennemie/Game3D_TrashDash.git
cd Game3D_TrashDash
```

Sau đó mở project bằng:

```text
Unity 6000.2.10f1
```

Phiên bản Unity này được khai báo trực tiếp trong `ProjectSettings/ProjectVersion.txt`.

---

# 🎬 Scenes

Project hiện có các scene chính:

```text
Assets/Scenes/

├── Intro.unity
├── GamePlay.unity
├── GamePlay_Profiles/
└── Start/
```

`GamePlay.unity` là scene gameplay chính của project.

---

# 📸 Screenshots

## Gameplay

<p align="center">
  <img src="docs/images/gameplay.png" width="850" alt="Trash Dash Gameplay">
</p>

## Environment

<p align="center">
  <img src="docs/images/environment.png" width="850" alt="Trash Dash Environment">
</p>

## UI

<p align="center">
  <img src="docs/images/ui.png" width="850" alt="Trash Dash UI">
</p>

> 📌 Tạo thư mục `docs/images/` và thêm screenshot thực tế của game vào đây.

---

# 🎥 Demo Video

> 🚧 Gameplay video coming soon.

Sau khi upload video lên YouTube, có thể thay phần này bằng thumbnail:

```markdown
[![Trash Dash Gameplay](https://img.youtube.com/vi/YOUR_VIDEO_ID/maxresdefault.jpg)](https://www.youtube.com/watch?v=YOUR_VIDEO_ID)
```

---

# 🧩 Development Highlights

Một số phần mình tập trung khi phát triển project:

### 🎮 Gameplay Programming

* Player controller
* Gameplay state
* Collectible interaction
* Moving environment
* Game manager
* Game settings

### 🎨 Game Presentation

* Cinemachine camera
* Lighting effects
* Spotlight effects
* Animation
* UI
* Audio

### 📦 Asset Management

Project sử dụng **Unity Addressables**, cho phép quản lý và load asset theo hệ thống Addressable thay vì chỉ phụ thuộc vào việc đặt asset trực tiếp trong scene. Package Addressables 2.7.4 được khai báo trong project.

---

# 📚 What I Learned

Thông qua project này, mình có cơ hội làm việc với:

* 🎮 Unity game development
* 💻 C# gameplay programming
* 🏃 Endless runner mechanics
* 🎥 Cinemachine
* 🎛️ Unity Input System
* 📦 Addressables
* 🎨 URP
* 💡 Lighting & visual effects
* 🧩 Modular gameplay architecture
* 🖥️ WebGL build
* 🪟 Windows build

---

# 🔮 Future Improvements

* [ ] Online WebGL demo
* [ ] High-score / leaderboard system
* [ ] Thêm nhiều loại obstacle
* [ ] Thêm nhiều collectible
* [ ] Thêm power-up
* [ ] Thêm character customization
* [ ] Cải thiện difficulty scaling
* [ ] Thêm sound effects cho gameplay events
* [ ] Cải thiện UI/UX
* [ ] Thêm mobile controls

---

# 👨‍💻 Author

**Ennemie**

<p align="center">
  <a href="https://github.com/Ennemie">
    <img src="https://img.shields.io/badge/GitHub-Ennemie-181717?style=for-the-badge&logo=github" alt="GitHub">
  </a>
</p>

---

# 🔗 Repository

<p align="center">

<a href="https://github.com/Ennemie/Game3D_TrashDash">
<img src="https://img.shields.io/badge/View%20Source%20Code-GitHub-181717?style=for-the-badge&logo=github" alt="View Source Code">
</a>

</p>

---

<p align="center">
  🐶 <b>Trash Dash</b>
  <br>
  <i>Run. Dodge. Collect. Repeat.</i>
</p>
