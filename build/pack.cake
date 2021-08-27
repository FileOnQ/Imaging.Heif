//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Pack")
    .Does(() =>
{
    if (!string.IsNullOrEmpty(githubRef))
    {
        version = githubRef
            .Split("/")
            .LastOrDefault()
            .TrimStart('v');
          
        if (version.Contains("-dev."))
        {
            var segments = version.Split("-");
            version = segments[0];
            suffix = segments[1];
        }
        else
        {
            suffix = string.Empty;
        }
    }
    
    MSBuild(csproj, msbuildSettings
        .WithTarget("pack")
        .WithProperty("PackageVersion", string.IsNullOrEmpty(suffix) ? version : $"{version}-{suffix}")
        .WithProperty("Version", version)
        .WithProperty("AssemblyVersion", version) 
        .WithProperty("PackageOutputPath", "../../"));
});