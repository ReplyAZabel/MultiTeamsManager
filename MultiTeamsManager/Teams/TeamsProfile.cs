using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTeamsManager.Teams;

public class TeamsProfile
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Disabled { get; set; }
    public bool Default { get; set; }

    public string Path { 
        get
        {
            return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Profiles", Id);
        } 
    }


    public TeamsProfile(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name}{(Default ? " (Default)" : "")}";
    }
}