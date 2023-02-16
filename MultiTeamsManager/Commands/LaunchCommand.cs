using MultiTeamsManager.Interfaces;
using MultiTeamsManager.Teams;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTeamsManager.Commands;

internal sealed class LaunchCommand : Command<LaunchCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("profiles")]
        [CommandOption("-p|--profiles")]
        public string[] Profiles { get; set; }
    }

    private readonly ITeamsProfileService _teamsProfileService;
    private readonly ITeamsService _teamsService;

    public LaunchCommand(ITeamsProfileService teamsProfileService, ITeamsService teamsService)
    {
        _teamsProfileService = teamsProfileService;
        _teamsService = teamsService;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        _teamsProfileService.Initialize();

        var profilesToLaunch = new List<TeamsProfile>();

        if (settings.Profiles != null && settings.Profiles.Length > 0)
        {
            profilesToLaunch = _teamsProfileService.Profiles.Where(profile => settings.Profiles.Contains(profile.Id)).ToList();
        }
        else
        {
            profilesToLaunch = _teamsProfileService.Profiles.Where(profile => !profile.Disabled).ToList();
        }

        profilesToLaunch.ForEach(profile =>
        {
            _teamsService.Launch(profile);

            AnsiConsole.MarkupLine($"Launched profile with name [blue]{profile.Name}[/] and id [blue]{profile.Id}[/].");
        });

        return 0;
    }
}
