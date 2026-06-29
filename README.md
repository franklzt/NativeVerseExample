# NativeVerseExample

Unreal Engine 6 Verse In Native Example

> Verse files can be placed under a plugin's `Content/` folder or under `Source/` folder. This repo contains two plugins demonstrating Verse integration in UE6.

---

## ⚠️ Warning

The `SetupVerse` call in `.Build.cs` contains a **hardcoded absolute path** pointing to Verse source files. You **must** modify this path to match your local project location before building.

**NativeVerseExample.Build.cs** (line 19-22):
```csharp
SetupVerse("/Verse.org/NativeVerseExample", VerseScope.PublicAPI,
    String.IsNullOrEmpty(TempDirectory)
        ? "/Source/NativeVerseExample/Verse"
        : "G:/Remake/VerseWorking/Plugins/NativeVerseExample/Source/NativeVerseExample/Verse");
//                                                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//                                                 Hardcoded path — change to your own path
```

**VerseDemoFeature.Build.cs** (line 10):
```csharp
SetupVerse("/Verse.org/SceneGraph", VerseScope.PublicAPI);
// No path override — uses default Content folder location
```

If your Verse files are under `Content/`, no path override is needed. If under `Source/`, provide the correct absolute or relative path in `SetupVerse`.

---

## Overview

`.uplugin` and `.Build.cs` are the key files to make Verse work for UE6.

### `.uplugin` — Key Verse Fields

| Field | Purpose | Example |
|---|---|---|
| `CanContainVerse` | Enables Verse content in plugin | `true` |
| `VersePath` | Verse namespace path | `"/localhost/VerseDemoFeature"` |
| `VerseScope` | Access level: `InternalUser` (Game Feature) or `PublicAPI` (standalone) | `"PublicAPI"` |
| `VerseVersion` | Verse version tracking | `0` |
| `EnableVerseAssetReflection` | Enables Verse asset reflection | `true` |
| `EnableSceneGraph` | Enables SceneGraph support | `true` |
| `Plugins` | Must include Verse ecosystem deps | Verse, VerseEngine, VerseSimulation, VerseSpatialMath, VerseTags, VerseRestricted, VerseColors, VerseVM, EntityFramework, etc. |

### `.Build.cs` — Key Verse Config

| Field | Purpose | Example |
|---|---|---|
| `SetupVerse()` | Registers Verse source path + scope | `SetupVerse("/Verse.org/NativeVerseExample", VerseScope.PublicAPI, "<path>")` |
| 1st arg | Verse namespace path | `"/Verse.org/SceneGraph"` or `"/Verse.org/NativeVerseExample"` |
| 2nd arg | `VerseScope.PublicAPI` or `VerseScope.InternalUser` | `VerseScope.PublicAPI` |
| 3rd arg (optional) | Custom path to `.verse` files (for `Source/` placement) | `"G:/Remake/.../Source/.../Verse"` |
| `PrivateDependencyModuleNames` | Verse modules required | `VerseNative`, `VerseEngine`, `VerseSimulation`, `VerseSpatialMath`, `VerseTags`, `VerseRestricted`, `VerseColors`, `Component` |
| `PublicDefinitions` | Enable native Verse | `WITH_VERSE_NATIVE=1` |
| `PCHUsage` | Precompiled header mode | `UseExplicitOrSharedPCHs` |

### Quick Rule

- **Verse in `Content/`** → `SetupVerse()` with 2 args (no path override needed)
- **Verse in `Source/`** → `SetupVerse()` with 3 args (path to Verse folder required) + `PublicDefinitions.Add("WITH_VERSE_NATIVE=1")`

---

## Plugins

### `VerseDemoFeature` (Content-Only)

A **content-only Game Feature plugin** demonstrating Verse-authored components with no custom C++ logic.

- **VerseScope:** InternalUser
- **VersePath:** `/localhost/VerseDemoFeature`
- **Verse files:** `Content/versefeaturn_component.verse`

#### `.uplugin` Plugin Dependencies

| Plugin                   | Notes                       |
|--------------------------|-----------------------------|
| Verse                    | Core Verse runtime          |
| VerseColors              | Color types                 |
| VerseEngine              | Verse engine integration    |
| VerseExperimental        | Experimental features       |
| VerseGameplayDebug       | Debug utilities             |
| VersePersonaMetadata     | Persona/editor metadata     |
| VersePrint               | Print/logging               |
| VerseRestricted          | Restricted API access       |
| VerseSimulation          | Simulation runtime          |
| VerseSimulationMetadata  | Simulation metadata         |
| VerseTags                | Tag system                  |
| VerseModifier            | Modifier system             |
| VerseSpatialMath         | Spatial math types          |
| VerseInterface           | Interface system            |
| VerseModuleIndependenceA | Module independence layer A |
| VerseModuleIndependenceB | Module independence layer B |
| VerseVM                  | Verse virtual machine       |
| UnrealEngineExperimental | UE experimental features    |
| EntityFramework          | Entity/component framework  |
| Solaris                  | Solaris integration         |

#### `.Build.cs` Module Dependencies

| Public      | Private                 |
|-------------|-------------------------|
| Core        | Entity                  |
| CoreUObject | VerseNative             |
| Engine      | VerseEngine             |
| InputCore   | VerseSimulation         |
|             | VerseSimulationMetadata |
|             | VerseSpatialMath        |
|             | VerseTags               |
|             | VerseRestricted         |
|             | VerseColors             |
|             | Component               |

---

### `NativeVerseExample` (C++ Backed)

A **standalone Verse plugin** demonstrating Verse <-> C++ interop with native `Damage()` method and event dispatch.

- **VerseScope:** PublicAPI
- **Defines:** `WITH_VERSE_NATIVE=1`
- **Verse files:** `Source/NativeVerseExample/Verse/VerseExampleComponent.native.verse`, `Source/NativeVerseExample/Verse/custom_component.native.verse`

#### `.uplugin` Plugin Dependencies

| Plugin                   | Notes                                 |
|--------------------------|---------------------------------------|
| ModelingToolsEditorMode  | Editor only (TargetAllowList: Editor) |
| Verse                    | Core Verse runtime                    |
| VerseColors              | Color types                           |
| VerseEngine              | Verse engine integration              |
| VerseExperimental        | Experimental features                 |
| VerseGameplayDebug       | Debug utilities                       |
| VersePersonaMetadata     | Persona/editor metadata               |
| VersePrint               | Print/logging                         |
| VerseRestricted          | Restricted API access                 |
| VerseSimulation          | Simulation runtime                    |
| VerseSimulationMetadata  | Simulation metadata                   |
| VerseTags                | Tag system                            |
| VerseModifier            | Modifier system                       |
| VerseSpatialMath         | Spatial math types                    |
| VerseInterface           | Interface system                      |
| VerseModuleIndependenceA | Module independence layer A           |
| VerseModuleIndependenceB | Module independence layer B           |
| VerseVM                  | Verse virtual machine                 |
| UnrealEngineExperimental | UE experimental features              |
| EntityFramework          | Entity/component framework            |
| Solaris                  | Solaris integration                   |

#### `.Build.cs` Module Dependencies

| Public      | Private                 |
|-------------|-------------------------|
| Core        | Entity                  |
| CoreUObject | VerseNative             |
| Engine      | VerseEngine             |
| InputCore   | VerseSimulation         |
|             | VerseSimulationMetadata |
|             | VerseSpatialMath        |
|             | VerseTags               |
|             | VerseRestricted         |
|             | VerseColors             |
|             | Component               |
|             | Verse                   |
|             | VersePrint              |

---

## Comparison

### Plugin Overview

|                       | VerseDemoFeature            | NativeVerseExample                            |
|-----------------------|-----------------------------|-----------------------------------------------|
| **Type**              | Content-only                | C++ backed                                    |
| **Scope**             | InternalUser (Game Feature) | PublicAPI (standalone)                        |
| **SetupVerse path**   | `/Verse.org/SceneGraph`     | `/Verse.org/NativeVerseExample` (custom path) |
| **Extra defines**     | None                        | `WITH_VERSE_NATIVE=1`                         |
| **Extra module deps** | None                        | `Verse`, `VersePrint`                         |
| **Editor plugin**     | None                        | `ModelingToolsEditorMode`                     |
| **Purpose**           | Basic Verse component demo  | Verse <-> C++ interop demo                    |

### `.Build.cs` Differences

| Aspect                 | VerseDemoFeature                             | NativeVerseExample                                                                         |
|------------------------|----------------------------------------------|--------------------------------------------------------------------------------------------|
| **Imports**            | `System`, `UnrealBuildTool`, `System.IO`     | `System`, `EpicGames.Core`, `Microsoft.Extensions.Logging`, `UnrealBuildTool`, `System.IO` |
| **SetupVerse**         | `"/Verse.org/SceneGraph"` (no path override) | `"/Verse.org/NativeVerseExample"` (custom path with fallback logic)                        |
| **PCHUsage**           | `PCHUsageMode.UseExplicitOrSharedPCHs`       | `ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs` (fully qualified)                       |
| **Logging**            | None                                         | `Log.Logger.LogWarning(...)` via `Microsoft.Extensions.Logging`                            |
| **Extra private deps** | —                                            | `Verse`, `VersePrint`                                                                      |
| **PublicDefinitions**  | —                                            | `WITH_VERSE_NATIVE=1`                                                                      |
