# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.4.0] - WIP

### Added

- New `Draw` class with additional methods compared to Unity's debug draw functions

## [1.3.0] - 2021/11/06

### Added

- New debug materials to visualize various vertex data
  - Bitangets
  - Normals
  - Tangents
  - UV1
  - UV2
  - VertexColor

## [1.2.0] - 2021/07/10

### Added

- Static class `Benchmark` to replace `ComparePerformance`
- Static class `Compare<T>` to replace `CompareResults<T>`
- Overloads for logging messages with custom prefixes
- New `Log.Assertion` methods

### Removed

- MonoBehaviour `ComparePerformance`
- MonoBehaviour `CompareResults<T>`

### Changed

- Package description
- Documentation comments
- [FPSDisplay]: The `SetDisplayFormat` method can now be overriden

## [1.1.0] - 2021/06/28

### Changed

- Improved FPS display formatting
- Namespace changed from DebugTools to Debug
- [AddComponentMenu] added to FPSDisplay

## [1.0.4] - 2021/04/13

### Changed

- Package description

### Fixed

- Moved non-compiled assets outside of the Runtime directory

## [1.0.3] - 2021/03/26

### Changed

- Renamed "Debug" class to "Log" to prevent naming conflict with Unity

## [1.0.2] - 2021/03/21

### Changed

- Updated package metadata

## [1.0.1] - 2021/03/07

### Changed

- Updated package metadata

## [1.0.0] - 2021/02/27

### Added

- Enhanced console logging
- Performance and equality testing
- FPS Display
- Shaders
  - Bitangets
  - Normals
  - Tangents
  - UV1
  - UV2
  - VertexColor
