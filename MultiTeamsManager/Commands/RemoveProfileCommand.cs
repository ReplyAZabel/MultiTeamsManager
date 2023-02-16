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

internal sealed class RemoveProfileCommand : Command<RemoveProfileCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("id")]
        [CommandArgument(0, "<id>")]
        public string? Id { get; init; }
    }

    private readonly ITeamsProfileService _teamsProfileService;
    public RemoveProfileCommand(ITeamsProfileService teamsProfileService)
    {
        _teamsProfileService = teamsProfileService;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        _teamsProfileService.Initialize();

        var removedProfile = _teamsProfileService.RemoveProfile(settings.Id);

        if(removedProfile == null)
        {
            AnsiConsole.MarkupLine($"Could not find a profile with id [blue]{settings.Id}[/].");

            return -1;
        }

        AnsiConsole.MarkupLine($"Removed profile with name [blue]{removedProfile.Name}[/] and id [blue]{removedProfile.Id}[/].");

        return 0;
    }
}
