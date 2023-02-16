using MultiTeamsManager.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace MultiTeamsManager.Startup;

public class StartupService : IStartupService
{
    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    internal class ShellLink
    {
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    internal interface IShellLink
    {
        void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd, int fFlags);
        void GetIDList(out IntPtr ppidl);
        void SetIDList(IntPtr pidl);
        void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        void GetHotkey(out short pwHotkey);
        void SetHotkey(short wHotkey);
        void GetShowCmd(out int piShowCmd);
        void SetShowCmd(int iShowCmd);
        void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
        void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
        void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
        void Resolve(IntPtr hwnd, int fFlags);
        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }

    const int SW_SHOWMINNOACTIVE = 7;

    public void AddToStartup()
    {
        IShellLink link = (IShellLink)new ShellLink();

        link.SetDescription("MultiTeamsManager");
        link.SetPath(Process.GetCurrentProcess().MainModule.FileName);
        link.SetArguments("launch");
        link.SetShowCmd(SW_SHOWMINNOACTIVE);
        link.SetWorkingDirectory(Environment.CurrentDirectory);

        IPersistFile file = (IPersistFile)link;

        file.Save(GetStartupLocation(), false);
    }

    public void RemoveFromStartup()
    {
        if (File.Exists(GetStartupLocation()))
        {
            File.Delete(GetStartupLocation());
        }
    }

    private string GetStartupLocation()
    {
        var startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

        return Path.Combine(startupPath, "MultiTeamsManager.lnk");
    }
}