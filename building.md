# How to Compile
FileOnQ.Imaging.Heif uses a mix of .NET Framework, .NET and native C/C++ projects. You will need to have additional build tools installed to properly build this locally. This readme serves as a guide for new developers to contribute.

## Build Dependencies
* Visual Studio 2019 for C++ Development
* [meson](https://mesonbuild.com/) (0.47 or higher)
* [ninja](https://ninja-build.org/)
* [nasm](https://nasm.us/) (2.14 or higher)

An easy way to install these dependencies is to use [Chocolatey](https://docs.chocolatey.org/en-us/choco/setup).

```
choco install meson
choco install ninja
choco install nasm
```

After installing you will need to ensure the installed build tools are all in your path. Ninja and meson are installed to the same directory, so you only need to add 2 directories.
```
C:\Program Files\NASM
C:\Program Files\Meson
```

*In our environment `nasm` was not automatically added to the path, but the other dependencies were*

## Compile
First time compilation takes a very long time, after you start the build go grab a cup of ☕ or 🍵. Our build agent runs the entire clean build in about 25-35 minutes, your build times may vary. Future builds won't take as long even if you do a clean and rebuild as vcpkg will cache binaries in your user directory. 

By compiling the main project `FileOnQ.Imaging.Heif` you will be compiling all native dependencies including the C++ encoding library `FileOnQ.Imaging.Heif.Encoders`. No need to run any additional compilation instructions.

### Visual Studio 
Right click on `FileOnQ.Imaging.Heif` and select build

### CLI

```
dotnet build src/FileOnQ.Imaging.Heif/FileOnQ.Imaging.Heif.csproj
```

## Build Scripts and Structure
The entire build process is orchestrated from `FileOnQ.Imaging.Heif.csproj` which includes downloading and compiling third party libraries. During the build you'll need to clone several git repositories and compile them. This leverages a combination of dotnet build targets and bat files. The build targets can be found in the `src/FileOnQ.Imaging.Heif/Build` directory. The build scripts or batch files can be found in the `build` directory.

The build targets and scripts should work out of the box if the required dependencies above have been installed. 
### Build Targets
The build targets located in the main project (FileOnQ.Imaging.Heif) are used to orchestrate builds for all supported platform architectures. They all follow a similar process
1. Clone repository for each supported platform architecture
2. Run build script (bat file)
3. Copy generated assemblies over to `src/FileOnQ.Imaging.Heif/runtimes/platform/native`

### Build Scripts (bat)
The build scripts load the Visual Studio Developer Command Prompt for the desired platform architecture and then run the build commands. This is really important when compiling native libraries for x86, x64, ARM, etc. Once the tools are loaded it compiles the code using the native toolchains. The bat scripts is where you will need to use the native build tools such as meson, ninja, nasm, cmake, nmake, etc.





