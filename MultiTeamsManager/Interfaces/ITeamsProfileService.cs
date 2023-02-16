using MultiTeamsManager.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MultiTeamsManager.Interfaces;
public interface ITeamsProfileService
{
    private const string PROFILES_PATH = "Profiles\\profiles.json";
    public List<TeamsProfile> Profiles { get; set; }

    public void Initialize();

    public TeamsProfile AddProfile(string name);
    public TeamsProfile RemoveProfile(string id);
    public TeamsProfile EnableProfile(string id);
    public TeamsProfile DisableProfile(string id);
    public TeamsProfile RenameProfile(string id, string newName);

    internal List<TeamsProfile> LoadProfilesFromDisk()
    {
        if (!File.Exists(PROFILES_PATH))
        {
            return new List<TeamsProfile>();
        }

        var json = File.ReadAllText(PROFILES_PATH);

        var profiles = JsonSerializer.Deserialize<List<TeamsProfile>>(json);

        return profiles;
    }
    internal void SaveProfilesToDisk()
    {
        var json = JsonSerializer.Serialize(Profiles, new JsonSerializerOptions()
        {
             WriteIndented = true
        });

        if (!Directory.Exists(Path.GetDirectoryName(PROFILES_PATH)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(PROFILES_PATH));
        }

        File.WriteAllText(PROFILES_PATH, json);
    }
}