using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTeamsManager.Interfaces;

public interface IStartupService
{
    public void AddToStartup();
    public void RemoveFromStartup();
}