using System.Net.Http;
using System.IO.Compression;
using System.Net.Mime;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace Shell
{
    class Program
    {

#pragma warning disable SYSLIB0014
        static string path;
        static void Main(string[] args) { init_shell(); }

        static void init_shell()
        {
            Console.Clear();
            path = Directory.GetCurrentDirectory();
            Console.Title = "Shell";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("YuNiiShell >> " + path);
            Console.WriteLine("Type 'help' for a list of commands.\r\n");
            Console.ForegroundColor = ConsoleColor.White;

            shell_loop();
        }

        static void clear_shell()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("YuNiiShell >> " + path);
            Console.WriteLine("Type 'help' for a list of commands.\r\n");
            Console.ForegroundColor = ConsoleColor.White;

            shell_loop();
        }

        static void throw_err(int id)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");

            switch (id)
            {
                case 1:
                    Console.WriteLine("The given path is not a valid Windows path. Please check your Syntax.");
                    break;

                case 2:
                    Console.WriteLine("There was a problem downloading the file. Please check your internet connection.");
                    break;

                case 3:
                    Console.WriteLine("The given file does not exist. Please check your Syntax.");
                    break;

                case 4:
                    Console.WriteLine("The given file already exists. Please check your Syntax.");
                    break;

                case 5:
                    Console.WriteLine("There was a problem uploading the file. Please check your internet connection.");
                    break;

                default:
                    Console.WriteLine("There was an error processing your command.");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }

        static void shell_loop()
        {
            string split_path = String.Concat("<", path.Split("\\")[path.Split("\\").Length - 2], "\\", path.Split("\\")[path.Split("\\").Length - 1]);

            Console.Write(split_path + ">$ ");
            string input = Console.ReadLine();
            string[] args = input.Split(" ");
            string cmd = args[0];

            switch (cmd.ToLower())
            {
                case "help":
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine("\r\n\tType 'help' for a list of commands.");
                    Console.WriteLine("\tType 'exit' to exit.");
                    Console.WriteLine("\tType 'clear' to clear the screen.\r\n");

                    Console.WriteLine("\tType 'cd' to change directory. [usage: cd !\"PATH\" || cd \"NEXT_FOLDER\" ||cd ..]");
                    Console.WriteLine("\tType 'ls' to list files in the current directory.");

                    Console.WriteLine("\tType 'pull' to download a file from the internet.");
                    Console.WriteLine("\tType 'push' to upload a file to the internet.\r\n");

                    Console.WriteLine("\tType 'mkdir' to create a directory.");
                    Console.WriteLine("\tType 'rmdir' to remove a directory.\r\n");

                    Console.WriteLine("\tType 'new' to create a file.");
                    Console.WriteLine("\tType 'rm' to remove a file.");
                    Console.WriteLine("\tType 'mv' to move a file.");
                    Console.WriteLine("\tType 'cp' to copy a file.");
                    Console.WriteLine("\tType 'cat' to view the contents of a file.\r\n");

                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case "exit":
                    Console.Clear();
                    Environment.Exit(0);
                    break;

                case "clear":
                    clear_shell();
                    break;

                case "cd":
                    if (args[1].StartsWith("!"))
                    {
                        if (Directory.Exists(args[1].Substring(1))) path = args[1].Substring(1);
                        else throw_err(1);
                    }

                    else if (args[1] == "..")
                    {
                        string[] path_temp = path.Split("\\");
                        path = "";
                        for (int i = 0; i < path_temp.Length - 1; i++)
                        {
                            if (i == 0) path = path + path_temp[i] + "\\";
                            else path = path + path_temp[i];
                        }
                    }

                    else if (!args[1].StartsWith("!") && args[1] != "..")
                    {
                        if (Directory.Exists(path + "\\" + args[1])) path = path + "\\" + args[1];
                        else throw_err(1);
                    }

                    else throw_err(1);

                    break;

                case "thisdir":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\r\n\t" + path + "\r\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case "ls":
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    DirectoryInfo d = new DirectoryInfo(path);
                    Console.WriteLine("\t<DIR>\r\n\t  " + path + "\r\n\r\n\t<FOLDERS>");
                    foreach (var dir in d.GetDirectories())
                    {
                        Console.WriteLine("\t  " + dir.Name);
                    }

                    Console.WriteLine("\r\n\t<FILES>");

                    foreach (var file in d.GetFiles())
                    {
                        Console.WriteLine("\t  " + file.Name);
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case "pull":
                    WebClient clientDown = new WebClient();
                    string url = args[1];
                    string filename = args[2];
                    clientDown.DownloadFile(url, path + "\\" + filename);
                    clientDown.Dispose();
                    break;

                case "push":

                    WebClient clientUp = new WebClient();
                    string url2 = args[1];
                    string filename2 = args[2];
                    byte[] response = clientUp.UploadFile(url2, path + "\\" + filename2);

                    string responseStr = "";
                    foreach (var bit in response)
                    {
                        responseStr += bit.ToString();
                    }

                    clientUp.Dispose();
                    break;

                case "mkdir":

                    if (args[1].StartsWith("!")) Directory.CreateDirectory(args[1]);
                    else Directory.CreateDirectory(path + "\\" + args[1]);

                    break;

                case "rmdir":

                    if (args[1].StartsWith("!")) Directory.Delete(args[1]);
                    else Directory.Delete(path + "\\" + args[1]);

                    break;

                case "new":
                    File.Create(path + "\\" + args[1]);
                    break;

                case "rm":

                    if (args[1].StartsWith("!"))
                    {
                        File.Delete(args[1]);
                    }
                    else
                    {
                        File.Delete(path + "\\" + args[1]);
                    }
                    break;

                case "mv":
                    
                        if (args[1].StartsWith("!") && args[2].StartsWith("!"))
                        {
                            File.Move(args[1], args[2]);
                        }
                        else
                        {
                            File.Move(path + "\\" + args[1], path + "\\" + args[2]);
                        }
                        break;

                case "cp":
                    if (args[1].StartsWith("!") && args[2].StartsWith("!"))
                    {
                        File.Copy(args[1], args[2]);
                    }
                    else
                    {
                        File.Copy(path + "\\" + args[1], path + "\\" + args[2]);
                    }
                    break;

                case "cat":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (args[1].StartsWith("!"))
                    {
                        Console.WriteLine();
                        Console.WriteLine(File.ReadAllText(args[1]));
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(File.ReadAllText(path + "\\" + args[1]));
                        Console.WriteLine();
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case "ip":
                    string ip = Dns.GetHostAddresses(Dns.GetHostName()).ToString();
                    foreach(var ip2 in ip) Console.WriteLine("\r\n\t" + ip2 + "\r\n");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\r\nCommand " + cmd + " not found! Type 'help' for commands!\r\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            shell_loop();

        }
    }
}
