using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MultiTeamsManager.Commands;
using MultiTeamsManager.Infrastructure;
using MultiTeamsManager.Interfaces;
using MultiTeamsManager.Startup;
using MultiTeamsManager.Teams;
using Spectre.Console;
using Spectre.Console.Cli;

namespace MultiTeamsManager;

internal class Program
{
    static int Main(string[] args)
    {
        Console.Title = "MultiTeamsManager";

        var registrations = new ServiceCollection();
        registrations.AddSingleton<ITeamsProfileService, TeamsProfileService>();
        registrations.AddSingleton<ITeamsService, TeamsService>();
        registrations.AddSingleton<IStartupService, StartupService>();

        var registrar = new TypeRegistrar(registrations);

        AnsiConsole.Write(new FigletText("MTM").Centered().Color(Color.SlateBlue3));

        var app = new CommandApp(registrar);
        app.Configure(config =>
        {
            config.SetApplicationName("MultiTeamsManager");
            config.AddCommand<LaunchCommand>("launch").WithDescription("Launch all or selected Teams profiles. Use -p or --profiles to set the profiles to launch");
            config.AddCommand<ListProfilesCommand>("list").WithDescription("List all profiles");
            config.AddCommand<AddProfileCommand>("add").WithDescription("Add a new profile");
            config.AddCommand<RemoveProfileCommand>("remove").WithDescription("Remove a profile");
            config.AddCommand<EnableProfileCommand>("enable").WithDescription("Enable a profile");
            config.AddCommand<DisableProfileCommand>("disable").WithDescription("Disable a profile");
            config.AddCommand<RenameProfileCommand>("rename").WithDescription("Rename a profile");
            config.AddCommand<AddToStartupCommand>("startup-add").WithDescription("Add MultiTeamsManager to startup");
            config.AddCommand<RemoveFromStartupCommand>("startup-remove").WithDescription("Remove MultiTeamsManager from startup");
        });

        return app.Run(args);
    }
}