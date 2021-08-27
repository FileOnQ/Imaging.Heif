#load "local:?path=build/clean.cake"
#load "local:?path=build/pack.cake"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Build");
var githubRef = Argument("ref", string.Empty); 
var version = Argument("package-version", "8.1.97");
var suffix = Argument("version-suffix", "alpha");
var configuration = Argument("configuration", "Release");
var solution = Argument("solution", "FileOnQ.Imaging.Heif.sln");
var sample = Argument("sample", "./sample/FileOnQ.Imaging.Heif.Sample.sln");
var csproj = Argument("csproj", "./src/FileOnQ.Imaging.Heif/FileOnQ.Imaging.Heif.csproj");

//////////////////////////////////////////////////////////////////////
// MSBuild Settings
//////////////////////////////////////////////////////////////////////
var msbuildSettings = new MSBuildSettings
{
    ToolVersion = MSBuildToolVersion.VS2019,
    Configuration = configuration
};

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Restore").Does(() => NuGetRestore(solution));

Task("Build").Does(() => MSBuild(solution, msbuildSettings));

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("CI-Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build");
    
Task("Package-Build")
    .IsDependentOn("CI-Build")
    .IsDependentOn("Pack");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);