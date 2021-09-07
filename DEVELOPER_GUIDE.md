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
```
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

## Test Projects
The test project contains unit and integration tests that will run the code all supported architectures and platforms. When working on changes locally, it is recommended to use NUnit directly. Using GUIs such as Visual Studio still work, but some the developer experience may differ from these docs.

The test projects all use a local NuGet package of `FileOnQ.Imaging.Heif.0.0.0-local.1` which is re-generated every time you build. The cached package in your NuGet Cache is also cleared to ensure you always have the latest changes. See Local NuGets below for more details.

The test projects use a shared project and target head solution to make it easier to manage what architecture is running the code.

```
tests/
├─ FileOnQ.Imaging.Heif.Tests.AnyCPU/
├─ FileOnQ.Imaging.Heif.Tests.x86/
├─ FileOnQ.Imaging.Heif.Tests.x65/
├─ FileOnQ.Imaging.Heif.Tests/
```

All test code should be added to the shared project, where the target heads just faciliate running the tests on the correct platform and arhitecture.

### Running the Tests (AnyCPU)
```
cd tests/FileOnQ.Imaging.Heif.Tests.AnyCPU
dotnet test
```

### Running the Tests (x86)
```
cd tests/FileOnQ.Imaging.Heif.Tests.x86
dotnet test
```

### Running the Tests (x64)
```
cd tests/FileOnQ.Imaging.Heif.Tests.x64
dotnet test
```

### Verbose Test Output
If you want to run the test project with extra verbose outputs
```
dotnet test --logger:"console;verbosity=detailed"
```

### Using Test Categories
The unit test project uses NUnit Test Categories. You can specify test categories to run specific groups of tests. The example below will only run the integration tests
```
dotnet test --filter TestCategory=Integration
```

### Solution File Unsupported
Currently you can't run tests from the solution file, only from the test project


## Sample Project(s)
The sample projects are a great way to see `FileOnQ.Imaging.Heif` in action. These projects all use local NuGet packages that are regenerated with each build. See the Local NuGets section below for more details how this works.

The sample projects have special target heads all supported architectures and platforms and use a shared project so the implementation code is the same.

## Benchmark Project
The benchmark project is used to validate performance and check for memory leaks. This project is used in the Pull Request review workflow to ensure we don't have performance degregation or new memory leaks with either the managed or native code. When working with this project locally, it uses our local NuGet pattern where it will clear out the existing package and regenerate it every time it builds. See the Local NuGets section below for more details on how this works.

The benchmark project use a native memory profiler which requires elevated administrative access to run. You will either need to run the benchmark from an elevated terminal or Visual Studio instance. It is required to build everything in release mode including the NuGet package.

You can specify various command line flags to determine which benchmark to run
```
cd benchmarks/tools
dotnet build -c Release
dotnet run -c Release -b thumbnail
```

If you want to see available benchmark commands
```
cd benchmarks/tools
dotnet run
```

## Local NuGets
We use local NuGets for several projects which are automatically generated by `dotnet build` commands. The tests, samples and benchmark projects all use this technique to ensure we are testing real-world NuGet scenarios with the native assemblies.

When debugging one of these packages, Visual Studio or your debugger will be able to step into the code with the local NuGet Package. There are custom build scripts built into each of these projects to ensure you always have a fresh NuGet package to use. They each implement the logic below:

Local Nuget Naming Convention
* `FileOnQ.Imaging.Heif.0.0.0-local.1`

On build of these projects
1. Clear your local NuGet cache
2. Pack `FileOnQ.Imaging.Heif` for release or debug configuration
3. dotnet restore
4. dotnet build

Using tools such as Visual Studio or JetBrains Rider you can still debug the binaries and step into them using this workflow. If it is not working as you expect, please log a new issue so it can be fixed.

All the build scripts can be found in their respective projects "Build" folder