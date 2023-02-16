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

internal sealed class AddToStartupCommand : Command<AddToStartupCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
    }

    private readonly IStartupService _startupService;
    public AddToStartupCommand(IStartupService startupService)
    {
        _startupService = startupService;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        _startupService.AddToStartup();

        AnsiConsole.MarkupLine("Added MultiTeamsManager to startup");

        return 0;
    }
}