# FileOnQ.Imaging.Heif
**This project is a work in progress all code is currently experimental**

A C#/.NET wrapper around [libheif](https://github.com/strukturag/libheif) to simplify opening heic images and retrieving thumbnails.

<!-- Add all badges here such as CI Build, wiki, etc. -->
[![Build (1.0.0)](https://github.com/FileOnQ/Imaging.Heif/actions/workflows/build_main.yml/badge.svg?branch=main)](https://github.com/FileOnQ/Imaging.Heif/actions/workflows/build_main.yml)
[![FileOnQ.Imaging.heif](https://img.shields.io/badge/NuGet-FileOnQ.Imaging.Heif-blue.svg)](https://www.nuget.org/packages/FileOnQ.Imaging.Heif)

## Contributing
⭐ Pull Requests and Issues are always welcomed ⭐
* [Contributing](CONTRIBUTING.md)
* [Developer Guide](DEVELOPER_GUIDE.md)
* [Building](BUILDING.md)

## Setup
Install the NuGet package into your target head and any shared projects.

[![FileOnQ.Imaging.heif](https://img.shields.io/badge/NuGet-FileOnQ.Imaging.Heif-blue.svg)](https://www.nuget.org/packages/FileOnQ.Imaging.Heif)

*The NuGet package must be included in the entry point or target head, otherwise the native assemblies won't be copied over to the bin directory correctly.*

## Supported Target Frameworks
FileOnQ.Imaging.Heif is available for use in the following target frameworks

| Platform         | Supported | Version                 |
|------------------|-----------|-------------------------|
| net48            | ✅        | 1.0.0                   |
| net5.0           | ✅        | 1.0.0                   |
| Xamarin.iOS      | ❌        | Planned                 |
| Xamarin.Mac      | ❌        | Planned                 |
| MonoAndroid      | ❌        | Planned                 |


## Supported Runtime Identifiers
FileOnQ.Imaging.Heif is available for use in the following runtime identifiers

| Platform         | Supported | Version                 |
|------------------|-----------|-------------------------|
| win-x86          | ✅        | 1.0.0                   |
| win-x64          | ✅        | 1.0.0                   |
| win-ARM64        | ❌        | Planned                 |
| osx-x64          | ❌        | Planned                 |
| linux-x64        | ❌        | Planned                 |

## Usage
Saves the primary image as a jpeg

```c#
using (var image = new HeifImage("image.heic"))
using (var primary = image.Primary())
{
    primary.Write("output.jpeg", 90);
}
```

Saves the embedded thumbnail as a jpeg

```c#
using (var image = new HeifImage("image.heic"))
using (var thumbnail = image.Thumbnail())
{
    thumbnail.Write("output.jpeg", 90);
}
```

## Documentation
We don't have a wiki or full API documentation. If you are interested in helping, create an issue so we can discuss.

# Dependencies
FileOnQ.Imaging.Heif uses several native C/C++ dependent libraries
* [libheif](https://github.com/strukturag/libheif)
* [dav1d](https://code.videolan.org/videolan/dav1d)
* [libjpeg-turbo](https://github.com/libjpeg-turbo/libjpeg-turbo)
* [libde265](https://github.com/strukturag/libde265)
* [x265](https://github.com/videolan/x265)

# Created By FileOnQ
This library was created by FileOnQ and donated to the open source community.