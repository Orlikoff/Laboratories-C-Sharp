using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace Music_Player
{
    class Program
    {
        // Creating Timer
        static Timer MyTimer = new Timer();

        // Declaring variables for saving current song
        static int CurrentSongIndex = -1;

        // Unmanaged Code
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string Cmd, StringBuilder StrReturn, int ReturnLength, IntPtr HwndCallback);
        // Unmanaged Code


        // Start Of Function "Add"
        static void Add(string SongName, string SongPath, List<string> SongList, List<string> PathList)
        {
            if (SongList.Contains(SongName))
            {
                if (CurrentSongIndex != -1)
                {
                    Stop(SongList, PathList);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Current song has been stopped due to the change of it's path!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                int index = SongList.FindIndex(a => a.Contains(SongName));
                SongList[index] = SongName;
                PathList[index] = SongPath;
            }
            else
            {
                SongList.Add(SongName);
                PathList.Add(SongPath);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Added '{SongPath}' as '{SongName}'");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        // End Of Function "Add"


        // Start Of Function "Play"
        static void Play(string SongName, List<string> SongList, List<string> PathList)
        {
            if (SongList.Count != 0)
            {
                if (SongList.Contains(SongName))
                {
                    if (CurrentSongIndex != -1)
                    {
                        Stop(SongList, PathList);
                    }
                    int index = SongList.FindIndex(a => a.Contains(SongName));
                    mciSendString("open \"" + PathList[index] + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
                    mciSendString("play " + PathList[index] + " from 0", null, 0, IntPtr.Zero);
                    CurrentSongIndex = index;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Playing '{SongList[CurrentSongIndex]}'");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no such song!" +
                        "\nYou can add one via 'add' command");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no songs in the list!" +
                    "\nYou can add one via 'add' command");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        // End Of Function "Play"


        // Start Of Function "Stop"
        static void Stop(List<string> SongList, List<string> PathList)
        {
            if (CurrentSongIndex != -1 && SongList.Count != 0)
            {
                mciSendString("stop " + PathList[CurrentSongIndex], null, 0, IntPtr.Zero);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Stopped '{SongList[CurrentSongIndex]}'");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                if (SongList.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nothing is palying at the moment!" +
                        "\nYou can play one via 'play' command");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no songs in the list!" +
                        "\nYou can add one via 'add' command");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        // End Of Function "Stop"


        // Start of Fucntion "Pause"
        static void Pause(List<string> SongList, List<string> PathList)
        {
            if (CurrentSongIndex != -1 && SongList.Count != 0)
            {
                mciSendString("pause " + PathList[CurrentSongIndex], null, 0, IntPtr.Zero);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Pausing '{SongList[CurrentSongIndex]}'");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                if (SongList.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nothing is palying at the moment!" +
                        "\nYou can play one via 'play' command");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are are songs in the list!" +
                        "\nYou can add one via 'add' command");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        // End of Function "Pause"


        // Start of Function "Resume"
        static void Resume(List<string> SongList, List<string> PathList)
        {
            if (CurrentSongIndex != -1 && SongList.Count != 0)
            {
                mciSendString("resume " + PathList[CurrentSongIndex], null, 0, IntPtr.Zero);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Resuming '{SongList[CurrentSongIndex]}'");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                if (SongList.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nothing is paused at the moment!" +
                        "\nYou can play one via 'play' command");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no songs in the list!" +
                        "\nYou can add one via 'add' command");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        // End of Function "Resume"


        // Start of Fnction "Current"
        static void Current(List<string> SongList)
        {
            if (CurrentSongIndex != -1 && SongList.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Current song is '{SongList[CurrentSongIndex]}'");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                if (SongList.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nothing is in the queue at the moment!" +
                        "\nYou can play one via 'play' command");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no songs in the list!" +
                        "\nYou can add one via 'add' command");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        // End of Function "Current"


        // Start of Function "Next"
        static void Next(List<string> SongList, List<string> PathList)
        {
            if (CurrentSongIndex != -1 && SongList.Count != 0)
            {
                Stop(SongList, PathList);
                if (CurrentSongIndex + 1 > SongList.Count - 1)
                {
                    CurrentSongIndex = 0;
                }
                else
                {
                    CurrentSongIndex++;
                }
                Play(SongList[CurrentSongIndex], SongList, PathList);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Next song '{SongList[CurrentSongIndex]}' started playing");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                if (SongList.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nothing is in the queue at the moment!" +
                        "\nYou can play one via 'play' command");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no songs in the list!" +
                        "\nYou can add one via 'add' command");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        // End of Function "Next"


        // Start of Function "PlayingTime"
        static int PlayingTime(List<string> PathList)
        {
            StringBuilder Return = new StringBuilder();
            mciSendString("status " + PathList[CurrentSongIndex] + " length", Return, Return.Capacity, IntPtr.Zero);
            return int.Parse(Return.ToString());
        }
        // End of Function "PlayingTime"


        // Start of Function "Auto"
        static void Auto(List<string> SongList, List<string> PathList)
        {
            Next(SongList, PathList);
            MyTimer = new Timer();
            MyTimer.Interval = PlayingTime(PathList) + 100;
            MyTimer.Elapsed += OnTimedEvent;
            MyTimer.Enabled = true;
            void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
            {
                Auto(SongList, PathList);
            }
        }
        // End of Function "Auto"


        // Main Program
        static void Main(string[] args)
        { 
            // Declaring Lists for Saving Songs
            List<string> SongList = new List<string>(); // For Song Name
            List<string> PathList = new List<string>(); // For It's Path

            // Reading from file "playlist.txt"
            string FILEPATH = @"./playlist.txt";
            using (StreamReader sr = new StreamReader(FILEPATH))
            {
                bool Read = true;
                do
                {
                    string Line = "";
                    Line = sr.ReadLine();
                    if (Line == null)
                    {
                        Read = false;
                        break;
                    }
                    Line = Line.Replace("\\", "/");
                    string[] Data = Line.Split("|");
                    SongList.Add(Data[1]);
                    PathList.Add(Data[0]);
                } while (Read != false);
            }
            CurrentSongIndex = 0;

            // Welcoming User and Giving Him Instrucions
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***** Welcome to the music player *****");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n---Instructions---");
            Console.WriteLine("It has the next functions to perform:\n" +
                              "\tplay [alias]  - Plays song with the alias\n" +
                              "\tauto - Plays all songs in auto mode\n" +
                              "\tadd [filepath] [alias]  - Add a composition\n" +
                              "\tnext  - Plays next song in the queue\n" +
                              "\tpause  - Pause a song\n" +
                              "\tresume  - Resume a song\n" +
                              "\tstop - Stop current song\n" +
                              "\ttime - Length of current song\n" +
                              "\tcurrent  - Shows the name of the song that is currently playing\n" +
                              "\texit - Exit from app\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            // Welcoming finished

            // Interacting with user
            bool exit = false;

            while (!exit)
            {
                Console.Write("> ");
                string RawInput = Console.ReadLine();
                RawInput = RawInput.Replace("\\", "/");
                string[] ParcedInput = RawInput.Split(" ");

                switch (ParcedInput[0])
                {
                    case "ad":
                    case "add":
                        {
                            try
                            {
                                Add(ParcedInput[2], ParcedInput[1], SongList, PathList);
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Check parameters of the function!");
                                Console.WriteLine("You can use 'help' to find instructions");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            break;
                        }
                    case "t":
                    case "time":
                        {
                            int Minutes = PlayingTime(PathList) / 1000 / 60;
                            int Seconds = PlayingTime(PathList) / 1000 - Minutes * 60;
                            Console.WriteLine($"Time of this song is: {Minutes} min and {Seconds} sec");
                            break;
                        }
                    case "pl":
                    case "play":
                        {
                            try
                            {
                                Play(ParcedInput[1], SongList, PathList);
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Check parameters of the function!");
                                Console.WriteLine("You can use 'help' to find instructions");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            break;
                        }
                    case "n":
                    case "next":
                        {
                            Next(SongList, PathList);
                            break;
                        }
                    case "m":
                    case "manual":
                        {
                            MyTimer.Dispose();
                            break;
                        }
                    case "s":
                    case "stop":
                        {
                            Stop(SongList, PathList);
                            break;
                        }
                    case "pa":
                    case "pause":
                        {
                            Pause(SongList, PathList);
                            break;
                        }
                    case "au":
                    case "auto":
                        {
                            Auto(SongList, PathList);
                            break;
                        }
                    case "r":
                    case "resume":
                        {
                            Resume(SongList, PathList);
                            break;
                        }
                    case "c":
                    case "current":
                        {
                            Current(SongList);
                            break;
                        }
                    case "e":
                    case "exit":
                        {
                            exit = true;
                            break;
                        }
                }
            }
        }
    }
}
