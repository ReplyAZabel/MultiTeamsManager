using MultiTeamsManager.Interfaces;
using Spectre.Console.Cli;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultiTeamsManager.Commands;

internal sealed class ListProfilesCommand : Command<ListProfilesCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
    }

    private readonly ITeamsProfileService _teamsProfileService;
    public ListProfilesCommand(ITeamsProfileService teamsProfileService)
    {
        _teamsProfileService = teamsProfileService;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        _teamsProfileService.Initialize();

        var table = new Table();
        table.AddColumns("Id", "Name", "Disabled");

        _teamsProfileService.Profiles.ForEach(profile =>
        {
            table.AddRow(profile.Id, $"{profile.Name}{(profile.Default ? " (Default)" : "")}", profile.Disabled.ToString());
        });

        AnsiConsole.Write(table);

        return 0;
    }
}