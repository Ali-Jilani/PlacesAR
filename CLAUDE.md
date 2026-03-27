# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

PlacesAR is a Unity 6 project using the Universal Render Pipeline (URP). It was created from the URP Blank template and appears to be set up for AR development (based on the project name and Android target configuration).

## Unity Version & Configuration

- **Template**: URP Blank (com.unity.template.urp-blank@17.0.14)
- **Render Pipeline**: Universal Render Pipeline 17.3.0
- **Scripting Backend**: IL2CPP (Android)
- **Input System**: New Input System 1.17.0 (active input handler)
- **Target Platforms**: Android (primary), iOS, Standalone

## Project Structure

```
Assets/
├── Scenes/              # Scene files (SampleScene.unity is the default)
├── Settings/            # URP render pipeline assets and profiles
│   ├── PC_RPAsset.asset       # Desktop render settings
│   ├── Mobile_RPAsset.asset   # Mobile render settings
│   ├── *_Renderer.asset       # Renderer configurations
│   └── *Profile.asset         # Volume profiles
├── InputSystem_Actions.inputactions  # Input action mappings
└── TutorialInfo/        # Unity template tutorial files (can be removed)
```

## Key Packages

- `com.unity.render-pipelines.universal` - URP rendering
- `com.unity.inputsystem` - New Input System
- `com.unity.ai.navigation` - AI Navigation/NavMesh
- `com.coplaydev.unity-mcp` - MCP for Unity integration

## Build Commands

Unity projects are built through the Unity Editor, not command line. To build:

1. Open project in Unity Hub
2. File → Build Settings
3. Select platform and build

For command-line builds (CI/CD):
```bash
Unity.exe -batchmode -projectPath "." -buildTarget Android -executeMethod BuildScript.Build -quit
```

## Code Conventions

- C# scripts go in `Assets/` (typically `Assets/Scripts/`)
- Editor-only scripts go in `Assets/Editor/` or folders named `Editor`
- Runtime assembly: `Assembly-CSharp`
- Editor assembly: `Assembly-CSharp-Editor`

## Working with Unity Files

- `.unity` files are YAML scene files - avoid manual editing
- `.prefab` files are YAML prefab definitions
- `.asset` files are serialized ScriptableObjects
- `.meta` files contain asset import settings and GUIDs - never delete without the associated asset
