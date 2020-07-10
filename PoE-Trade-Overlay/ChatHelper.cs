using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PoE_Trade_Overlay
{
    public class ChatHelper
    {
        public static bool IsPoeOpen()
        {
            Process[] processes = Process.GetProcessesByName("PathOfExile_x64Steam");
            Process[] processClient = Process.GetProcessesByName("PathOfExile_x64");
            Process[] allProcesses = processes.Union(processClient).ToArray();
            return (allProcesses.Length != 0);
        }

        // Scancodes can be found here (Set 1) : https://www.win.tue.nl/~aeb/linux/kbd/scancodes-10.html

        public static void SendChatMessage(string msg)
        {
            Process[] processes = Process.GetProcessesByName("PathOfExile_x64Steam");
            Process[] processClient = Process.GetProcessesByName("PathOfExile_x64");
            Process[] allProcesses = processes.Union(processClient).ToArray();

            string oldMessage = Clipboard.GetText();

            Clipboard.SetText(msg);
            if (allProcesses.Length != 0)
            {
                Send.BringToFront(allProcesses[0]);

                Send.SendKey(0x1C, Send.KeyEventF.KeyDown);  // Open Chat
                System.Threading.Thread.Sleep(100);
                Send.SendKey(0x1C, Send.KeyEventF.KeyUp);   // Clear Enter Key Event

                Send.SendKey(0x1D, Send.KeyEventF.KeyDown);  // KeyDown CTRL
                System.Threading.Thread.Sleep(10);
                Send.SendKey(0x2F, Send.KeyEventF.KeyDown);  // KeyDown V

                Send.SendKey(0x1D, Send.KeyEventF.KeyUp);  // KeyDown CTRL
                System.Threading.Thread.Sleep(10);
                Send.SendKey(0x2F, Send.KeyEventF.KeyUp);  // KeyDown V

                Send.SendKey(0x1C, Send.KeyEventF.KeyDown);  // Send Message
                System.Threading.Thread.Sleep(100);
                Send.SendKey(0x1C, Send.KeyEventF.KeyUp);   // Clear Enter Key Event
            }

            try
            {
                if (oldMessage != string.Empty)
                    Clipboard.SetText(oldMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine("ChatHelper::SendChatMessage Exception : " + e.Message);
            }
        }
    }
}