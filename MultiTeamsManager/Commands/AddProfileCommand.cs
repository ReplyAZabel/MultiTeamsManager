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

internal sealed class AddProfileCommand : Command<AddProfileCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("name")]
        [CommandArgument(0, "<name>")]
        public string? Name { get; init; }
    }

    private readonly ITeamsProfileService _teamsProfileService;
    public AddProfileCommand(ITeamsProfileService teamsProfileService)
    {
        _teamsProfileService = teamsProfileService;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        _teamsProfileService.Initialize();

        var addedProfile = _teamsProfileService.AddProfile(settings.Name);

        if (addedProfile == null)
        {
            AnsiConsole.MarkupLine($"Could not add a profile with name [blue]{settings.Name}[/].");

            return -1;
        }

        AnsiConsole.MarkupLine($"Added profile with name [blue]{addedProfile.Name}[/] and id [blue]{addedProfile.Id}[/].");

        return 0;
    }
}
