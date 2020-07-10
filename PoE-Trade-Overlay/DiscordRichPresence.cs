using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PoE_Trade_Overlay
{
    public class DiscordRichPresence
    {
        public DiscordRpcClient client;
        private string path = Config.GetEntry("Client");
        private string lastZone = "";
        private Timer t;
        private long oldFileLength;

        public DiscordRichPresence()
        {
            Initialize();
            GetLastZone(path);
            oldFileLength = new FileInfo(path).Length;

            t = new Timer()
            {
                Interval = 1000,
                Enabled = true
            };
            t.Tick += T_Tick;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            long newFileLength = new FileInfo(path).Length;
            if (oldFileLength != newFileLength)
            {
                oldFileLength = newFileLength;

                /*
                client = new DiscordRpcClient("603668113833328650");

                //Set the logger
                client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

                //Subscribe to events
                client.OnReady += (sender1, e1) =>
                {
                    Console.WriteLine("Received Ready from user {0}", e1.User.Username);
                };

                client.OnPresenceUpdate += (sender1, e1) =>
                {
                    Console.WriteLine("Received Update! {0}", e1.Presence);
                };

                //Connect to the RPC
                client.Initialize();

                //Set the rich presence
                //Call this as many times as you want and anywhere in your code.

                */
                //Console.WriteLine("Send Update");
                client.SetPresence(new RichPresence()
                {
                    Details = "Current Zone :",
                    State = GetLastZone(path),
                    Assets = new Assets()
                    {
                        LargeImageKey = "poe"
                    }
                });
                client.SynchronizeState();
            }
            else
            {
            }
        }

        private string GetLastZone(string path)
        {
            StreamReader sr = new StreamReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

            string[] lines = Tail(sr, 9);

            for (int i = lines.Length - 1; i > 0; i--)
            {
                if (lines[i].Contains("] : You have entered "))
                {
                    string l = lines[i];
                    return l.Between("] : You have entered ", ".");
                }
            }
            return "   ";
        }

        private string[] Tail(StreamReader reader, int lineCount)
        {
            var buffer = new List<string>(lineCount);
            string line;
            for (int i = 0; i < lineCount; i++)
            {
                line = reader.ReadLine();
                if (line == null) return buffer.ToArray();
                buffer.Add(line);
            }

            int lastLine = lineCount - 1;           //The index of the last line read from the buffer.  Everything > this index was read earlier than everything <= this indes

            while (null != (line = reader.ReadLine()))
            {
                lastLine++;
                if (lastLine == lineCount) lastLine = 0;
                buffer[lastLine] = line;
            }

            if (lastLine == lineCount - 1) return buffer.ToArray();
            var retVal = new string[lineCount];
            buffer.CopyTo(lastLine + 1, retVal, 0, lineCount - lastLine - 1);
            buffer.CopyTo(0, retVal, lineCount - lastLine - 1, lastLine + 1);
            return retVal;
        }

        private void Initialize()
        {
            /*
            Create a discord client
            NOTE: 	If you are using Unity3D, you must use the full constructor and define
                     the pipe connection.
            */
            client = new DiscordRpcClient("603668113833328650");

            //Set the logger
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                //Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                //Console.WriteLine("Received Update! {0}", e.Presence);
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = "Current Zone :",
                State = GetLastZone(path),
                Assets = new Assets()
                {
                    LargeImageKey = "poe",
                    LargeImageText = "Path of Exile 1"
                }
            });
        }
    }
}