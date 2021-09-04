# Developer Guide
The developer guide is an on-boarding document for new contributors to FileOnQ.Imaging.Heif. This project implements some non-standard practices and the goal of this document is to answer questions and explain how the code works.

## Compiling/Building
If you haven't read the [Building](BUILDING.md) steps, go and do that first. You will need to setup your development environment with several native C/C++ tools before you can continue. Once you have completed, that you should be able to compile the application.

Easiest way to determine if you can compile the application is to build the main project `FileOnQ.Imaging.Heif`. If this is your first time, it may take 20-30 minutes.
```
cd src/FileOnQ.Imaging.Heif
dotnet build
```

### Native Assemblies
This project uses several native C/C++ assemblies that are hooked into the standard .NET build process. After a successful build you should see a new `runtimes` folder populated in `FileOnQ.Imaging.Heif` project.
```angular2html
runtimes/
├─ win-x64/
│  ├─ dav1d.dll
│  ├─ FileOnQ.Imaging.Heif.Encoders.dll
│  ├─ heif.dll
│  ├─ jpeg62.dll
│  ├─ libde265.dll
│  ├─ libx265.dll
├─ win-x86/
│  ├─ dav1d.dll
│  ├─ FileOnQ.Imaging.Heif.Encoders.dll
│  ├─ heif.dll
│  ├─ jpeg62.dll
│  ├─ libde265.dll
│  ├─ libx265.dll
```

If you need to make any changes to how these assemblies are generated you will need to look at the additional build files.
* Targets files are located at [src\FileOnQ.Imaging.Heif\Build](src\FileOnQ.Imaging.Heif\Build)
* Batch files are located at [build](build)

## Core Code - FileOnQ.Imaging.Heif
The core API is built in the main project FileOnQ.Imaging.Heif. There is a special build that generates all of the native assemblies. Other than that everything for compiling and packaging this project follows standard best practices.

## Local NuGets
The test, samples, and benchmark project all use local NuGets to simplify the integration with the native assemblies. This means if you are debugging test code you need to generate a NuGet package to get the latest changes. There are custom build scripts built into each of these projects to ensure you always have a fresh NuGet package to use. They each implement the logic below:

On build of these projects
1. Delete `FileOnQ.Imaging.Heif.0.0.0-local.1` from your local NuGet cache
2. Pack `FileOnQ.Imaging.Heif` for release or debug configuration
3. dotnet restore
4. dotnet build

Using tools such as Visual Studio or JetBrains Rider you can still debug the binaries and step into them using this workflow. If it is not working as you expect, please log a new issue so it can be fixed.

All the build scripts can be found in their respective projects "Build" folder