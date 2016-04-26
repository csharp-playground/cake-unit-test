
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var buildDir = Directory("./src/Example/bin") + Directory(configuration);

Task("Clean").Does(() => {
        CleanDirectory(buildDir);
});

Task("RunUnitTest")
    .IsDependentOn("Build")
    .Does(() => {
        NUnit3("./src/Example/bin/" + configuration + "/Example.dll", new NUnit3Settings {
            NoResults = true
        });
});

Task("RestoreNugetPackages")
    .IsDependentOn("Clean")
    .Does(() => {
        NuGetRestore("./src/Example/Example.fsproj");
});

Task("Build")
    .IsDependentOn("RestoreNugetPackages")
    .Does(() => {
        if(IsRunningOnWindows()) {

        }else {
            XBuild("./src/Example/Example.fsproj", settings => {
                    settings.SetConfiguration(configuration);
            });
        }
});

Task("Default").IsDependentOn("RunUnitTest");

RunTarget(target);