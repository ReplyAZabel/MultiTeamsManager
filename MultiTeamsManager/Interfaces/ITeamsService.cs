using MultiTeamsManager.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTeamsManager.Interfaces;

public interface ITeamsService
{
    public void Launch(TeamsProfile profile);
}