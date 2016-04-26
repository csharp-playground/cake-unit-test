
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var buildDir = Directory("./src/Example/bin") + Directory(configuration);

Task("Clean").Does(() => {
        CleanDirectory(buildDir);
});

Task("Default").IsDependentOn("Clean");

RunTarget(target);