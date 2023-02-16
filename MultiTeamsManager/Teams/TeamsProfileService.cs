using MultiTeamsManager.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultiTeamsManager.Teams;

public class TeamsProfileService : ITeamsProfileService
{
    public List<TeamsProfile> Profiles { get; set; }

    public TeamsProfileService()
    {

    }

    public void Initialize()
    {
        Profiles = ((ITeamsProfileService)this).LoadProfilesFromDisk();

        var defaultProfile = Profiles.FirstOrDefault(x => x.Default);

        if(defaultProfile == null)
        {
            AddProfile("Default");

            SetDefault(Profiles?.FirstOrDefault()?.Id);
        }
    }

    public TeamsProfile AddProfile(string name)
    {
        var profile = new TeamsProfile(Guid.NewGuid().ToString(), name);
        Profiles.Add(profile);
        ((ITeamsProfileService)this).SaveProfilesToDisk();

        return profile;
    }

    public TeamsProfile RemoveProfile(string id)
    {
        var profile = Profiles.FirstOrDefault(x => x.Id == id);

        if (profile != null)
        {
            Profiles.Remove(profile);

            ((ITeamsProfileService)this).SaveProfilesToDisk();
        }

        return profile;
    }

    public TeamsProfile EnableProfile(string id)
    {
        var profile = Profiles.FirstOrDefault(x => x.Id == id);

        if(profile != null)
        {
            profile.Disabled = false;

            ((ITeamsProfileService)this).SaveProfilesToDisk();
        }

        return profile;
    }

    public TeamsProfile DisableProfile(string id)
    {
        var profile = Profiles.FirstOrDefault(x => x.Id == id);

        if (profile != null)
        {
            profile.Disabled = false;

            ((ITeamsProfileService)this).SaveProfilesToDisk();
        }

        return profile;
    }

    public TeamsProfile RenameProfile(string id, string newName)
    {
        var profile = Profiles.FirstOrDefault(x => x.Id == id);

        if (profile != null)
        {
            profile.Name = newName;

            ((ITeamsProfileService)this).SaveProfilesToDisk();
        }

        return profile;
    }

    private void SetDefault(string id)
    {
        var profile = Profiles.FirstOrDefault(x => x.Id == id);

        if (profile != null)
        {
            profile.Default = true;

            ((ITeamsProfileService)this).SaveProfilesToDisk();
        }
    }
}