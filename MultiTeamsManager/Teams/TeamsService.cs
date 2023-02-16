using MultiTeamsManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTeamsManager.Teams;
public class TeamsService : ITeamsService
{
    public void Launch(TeamsProfile profile)
    {
        string updateExePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"AppData\Local\Microsoft\Teams\Update.exe");

        var profilePath = profile.Default ? Environment.GetEnvironmentVariable("USERPROFILE") : profile.Path;

        LaunchTeams(updateExePath, profilePath);
    }

    private void LaunchTeams(string updateExePath, string profilePath)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = updateExePath,
            Arguments = "--processStart Teams.exe",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };
        startInfo.EnvironmentVariables["USERPROFILE"] = profilePath;

        var updateExeProcess = new Process() { StartInfo = startInfo };

        updateExeProcess.Start();
        while (!updateExeProcess.StandardOutput.EndOfStream) { }
        updateExeProcess.WaitForExit();
    }
}