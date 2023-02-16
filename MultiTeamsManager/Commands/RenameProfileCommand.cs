using MultiTeamsManager.Interfaces;
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

internal sealed class RenameProfileCommand : Command<RenameProfileCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("id")]
        [CommandArgument(0, "<id>")]
        public string? Id { get; init; }

        [Description("newname")]
        [CommandArgument(1, "<newname>")]
        public string? NewName { get; init; }
    }

    private readonly ITeamsProfileService _teamsProfileService;
    public RenameProfileCommand(ITeamsProfileService teamsProfileService)
    {
        _teamsProfileService = teamsProfileService;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        _teamsProfileService.Initialize();

        var oldProfile = _teamsProfileService.Profiles.FirstOrDefault(x => x.Id == settings.Id);

        if(oldProfile == null) 
        {
            AnsiConsole.MarkupLine($"Could not find a profile with id [blue]{settings.Id}[/].");

            return -1;
        }

        var oldProfileName = oldProfile.Name;

        var renamedProfile = _teamsProfileService.RenameProfile(settings.Id, settings.NewName);

        if (oldProfile == null)
        {
            AnsiConsole.MarkupLine($"Could not find a profile with id [blue]{settings.Id}[/].");

            return -1;
        }

        AnsiConsole.MarkupLine($"Renamed profile with name [blue]{oldProfileName}[/] and id [blue]{renamedProfile.Id}[/] to [blue]{renamedProfile.Name}[/].");

        return 0;
    }
}
