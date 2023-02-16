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

internal sealed class EnableProfileCommand : Command<EnableProfileCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("id")]
        [CommandArgument(0, "<id>")]
        public string? Id { get; init; }
    }

    private readonly ITeamsProfileService _teamsProfileService;
    public EnableProfileCommand(ITeamsProfileService teamsProfileService)
    {
        _teamsProfileService = teamsProfileService;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        _teamsProfileService.Initialize();

        var enabledProfile = _teamsProfileService.EnableProfile(settings.Id);

        if(enabledProfile == null)
        {
            AnsiConsole.MarkupLine($"Could not find a profile with id [blue]{settings.Id}[/].");

            return -1;
        }

        AnsiConsole.MarkupLine($"Enabled profile with name [blue]{enabledProfile.Name}[/] and id [blue]{enabledProfile.Id}[/].");

        return 0;
    }
}
