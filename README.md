![logo](https://github.com/YuNiiWorks/dShell/blob/main/img/dShell_logo_png.png)
A basic Command Prompt stand-in written in C#. This project is specifically written by Benjamin "YuNii" Henrich.

---
## Table of Contents
- [dShell](#dshell)
  * [Install](#install)
    + [1. Downloading the Release.](#1-downloading-the-release)
    + [2. Adding dShell.exe to PATH.](#2-adding-dshellexe-to-path)
    + [3. Restart your shell.](#3-restart-your-shell)
    + [(OPTIONAL) Replacing cmd.](#-optional--replacing-cmd)
  * [Command Syntax Documantation](#command-syntax-documantation)
  * [Changelog & Roadmap](#changelog---roadmap)
    + [Planned for the next Release](#planned-for-the-next-release)
    + [12/24/2022 - v0.1](#12-24-2022---v01)
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
## Command Syntax Documantation
*NOTE: Full paths are declared using a literacy operator:* **!**

- 'help'
    - Show a list of commands.
- 'exit'
    - Exit the command prompt.
- 'clear'
    - Clear the screen.
- 'cd' ![FULL_PATH] | [FOLDER] | '..'
    - Change the current active directory. Use '..' to go back one folder.
- 'ls'
    - List all files and folders in the current active directory.
- 'pull' [URL] [OUT_FILE_NAME]
    - Download a file from [URL] and save it as [OUT_FILE_NAME] in the current active directory.
- 'push' [URL] [IN_FILE_NAME]
    - Upload [OUT_FILE_NAME] to [URL].
- 'mkdir' ![FULL_PATH] | [FOLDER]
    - Create a new directory.
- 'rmdir' ![FULL_PATH] | [FOLDER]
    - Remove a directory (recursively!).
- 'new' [FILE_NAME]
    - Create a new file called [FILE_NAME] in the current active directory.
- 'rm' ![FULL_PATH] | [FILE_NAME]
    - Delete a file.
- 'mv' ![FULL_PATH_SRC] ![FULL_PATH_DST] | [FILE_SRC] [FILE_DST]
    - Move a file providing either two full paths, or two filenames in the current active directory.
- 'cp' ![FULL_PATH_SRC] ![FULL_PATH_DST] | [FILE_SRC] [FILE_DST]
    - Copy a file providing either two full paths, or two filenames in the current active directory.
- 'cat' ![FULL_PATH] | [FILE]
    - Read a file.

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
