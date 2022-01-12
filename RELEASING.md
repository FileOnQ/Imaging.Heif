# Builds and Releasing
FileOnQ.Imaging.Heif has three builds: PR, Main, and Benchmark. This readme serves as a guide for developers to understand each of their purposes and how to trigger a release build.

## Benchmark Build
This build compares incoming code change performance benchmark results to a baseline result set. The benchmarks test the Primary and Thumbnail APIs for all targeted frameworks (.NET 4.8, .NET 5, .NET 6). After benchmarks have been completed, the results are compared to the baseline and the results are commented onto the Pull Request.

## PR Build
This build is used for all PRs into the main branch. This builds the Heif project and publishes a PR version NuGet Package to Nuget. After the project is build and packaged, it executes the console applications for all frameworks and architecture to ensure it works correctly with the package created. After the console applications have been executed, all of the WinForms applications are BUILT to ensure they still compile using the nuget package.

## Release Build
The Release build is the main build that publishes the release build nuget packages to nuget. It is triggered when a push to main occurs or a tag starting with v* or v*-preview-* is created. The build itself is very similar to the PR build. The only difference is how the NuGet Package version is determined. The determination of the version is documented in more detail below.

## Triggering Release Build 
In order to trigger the Release Build one of the following items has to occur:

* Push to Main Branch
* Tag push or created matching v* or v*-preview-*

## Version Schema
Below are the schemas used for versioning the NuGet Package for PR and Release Builds

### PR Build
The version schema used for PR builds is LatestMajor.0.0-pr.GITHUB.RUN_NUMBER. For example if the latest version is 1.0.0 and the build run number is 80, the version used would be 1.0.0-pr.80

### Release Build
There are two version schemas used for release builds.
#### Main Branch Push
The version used for main branch pushes is LatestMajor.0.0-dev.GITHUB.RUN_NUMBER. For example, if the latest version is 1.0.0 and the build run number is 96, the version used would be 1.0.0-dev.96.
#### Tag
The version used for a tag trigged release build is the 3 number semantic used during tag creation. For example version 1 will be 1.0.0 with the tag of v1.0.0


