//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild") || target.ToLower() == "clean")
    .Does(() =>
{
    var directories = GetDirectories("./src/**/bin");
    directories.Add(GetDirectories("./src/**/obj"));
    directories.Add(GetDirectories("./packages"));
    directories.Add(GetDirectories("./artifacts"));
    directories.Add(GetDirectories("./tests/**/bin"));
    directories.Add(GetDirectories("./tests/**/obj"));
    directories.Add(GetDirectories("./sample/**/obj"));
    directories.Add(GetDirectories("./sample/**/obj"));
    directories.Add(GetDirectories("*.nupkg"));

    var files = GetFiles("*.zip");

    if (directories.Count > 0 || files.Count > 0)
    {
        foreach (var directory in directories)
        {
            Information($"Deleting directory - {directory}");
            DeleteDirectory(directory, new DeleteDirectorySettings
            {
                Recursive = true,
                Force = true
            });
        }

        foreach (var file in files)
        {
            Information($"Deleting file - {file}");
            DeleteFile(file);
        }
    }
    else
    {
        Information("No directories to remove");
        Information("No files to remove");
    }
});