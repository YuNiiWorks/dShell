# dShell
A basic Command Prompt stand-in written in C#. This project is specifically written by Benjamin "YuNii" Henrich.

---
## Install
### 1. Downloading the Release.
- Go to the 'Release' tab and download the latest version of dShell.
- Save the .exe file in your Windows folder (C:\Windows\system32) or any folder you can remember, like Documents.

### 2. Adding dShell.exe to PATH.
- Edit your PATH Enviroment Variable.
- Add a new path. Make sure you enter the full path including the dShell.exe (e.g: 'C:\Windows\system32\dShell.exe').

### 3. Restart your shell.
- Restart your command prompt or windows powershell window. You should be able to run dShell by typing the 'dShell' command.

### (OPTIONAL) Replacing cmd.
If you want, you can replace the standart windows command prompt with dShell. Note that this is an option, but not recommended since dShell is currently missing a lot of planned functionality.
- Open your system32 folder in explorer ('C:\Windows\system32').
- Rename cmd.exe to cmd_backup.exe - DO NOT DELETE THE FILE.
- Rename dShell.exe to cmd.exe.
- Restart your command prompt or windows powershell window.

### Should you run into any problems during the install process, or while using dShell, write an [E-Mail to our support.](mailto://support@yuniiworks.de)

---
## Changelog & Roadmap

*NOTICE: dShell is a hobby project and will not receive a steady flow of updates. Updates to dShell's development can be found on our [Twitter Page.](https://twitter.com/yuniiworks)*

### Planned for the next Release
- System Management Commands
    - 'ip' to view your IP Adress
    - 'host' to view/edit your hostname
    - 'user' to view/edit your username
    - 'date' to view the current date
    - 'time' to view the current time
    - 'os' to view the current operating system
    - 'version' to view the current dShell version
    - 'arch' to view your current os architecture

### 12/24/2022 - v0.1
- First release of dShell. Includes the commands *'help, exit, clear, cd, ls, push, pull, mkdir, rmdir, new, rm, mv, cp, cat'* See the Documentation for help with each command.
