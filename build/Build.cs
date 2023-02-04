using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.MSBuild;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;

class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    [Solution]
    private readonly Solution Solution;
    private readonly string _version = "0.44";

    public static int Main() => Execute<Build>(x => x.BuildSolution);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
        });

    Target Restore => _ => _
        .Executes(() =>
        {
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            MSBuild(s => s
            .SetTargetPath(Solution)
            .SetConfiguration(Configuration.Release)
            .SetTargets("Rebuild"));
        });

    Target MoveDllToTsepFolder => _ => _
    .Executes(() => Service.MoveFileToTargetFolder.Move(Solution)
    );

    Target RewriteTsepXML => _ => _
    .Executes(() => Service.TsepXmlWriter.Write(Solution, _version)
    );

    Target BuildSolution => _ => _
    .DependsOn(MoveDllToTsepFolder)
    .DependsOn(RewriteTsepXML)
    .DependsOn(Compile);
}
