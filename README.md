# Debug Tools

[![](https://img.shields.io/badge/github-repo-blue?logo=github)](https://github.com/zigurous/unity-debug-tools) [![](https://img.shields.io/github/package-json/v/zigurous/unity-debug-tools)](https://github.com/zigurous/unity-debug-tools/releases) [![](https://img.shields.io/badge/docs-link-success)](https://docs.zigurous.com/com.zigurous.debug) [![](https://img.shields.io/github/license/zigurous/unity-debug-tools)](https://github.com/zigurous/unity-debug-tools/blob/main/LICENSE.md)

The **Debug Tools** package contains assets and scripts for debugging Unity projects. Included in the package are scripts for enhanced console logging, benchmarking, displaying framerate, and more. The package also comes with shaders to visualize different vertex data.

## Reference

- [Logging](https://docs.zigurous.com/com.zigurous.debug/manual/logging)
- [Benchmarking](https://docs.zigurous.com/com.zigurous.debug/manual/benchmarking)
- [Framerate Display](https://docs.zigurous.com/com.zigurous.debug/manual/framerate)
- [Debug Shaders](https://docs.zigurous.com/com.zigurous.debug/manual/shaders)

## Installation

Use the Unity [Package Manager](https://docs.unity3d.com/Manual/upm-ui.html) to install the **Debug Tools** package.

1. Open the Package Manager in `Window > Package Manager`
2. Click the add (`+`) button in the status bar
3. Select `Add package from git URL` from the add menu
4. Enter the following Git URL in the text box and click Add:

```
https://github.com/zigurous/unity-debug-tools.git
```

## Namespace

Import the package namespace in each script or file you want to use it. You may need to regenerate project files/assemblies first.

```csharp
using Zigurous.Debug;
```
