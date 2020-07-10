using PoE_Trade_Overlay.Controls;
using PoE_Trade_Overlay.Queries;
using System;
using System.Data;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace PoE_Trade_Overlay
{
    public static class Extensions
    {
        public static int debugHeaderWidth = 70;

        public static bool BetterContains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

        public static bool IsNumber(this string source)
        {
            int n;
            return int.TryParse(source, out n);
        }

        public static PuneHedgehog SetDataFromFilterControl(Controls.Filter filterControl)
        {
            PuneHedgehog source = new PuneHedgehog();

            string min = filterControl.GetMin();
            string max = filterControl.GetMax();

            if (min != null)
                source.Min = min.ToLong();
            else
                source.Min = null;

            if (max != null)
                source.Max = max.ToLong();
            else
                source.Max = null;

            return source;
        }

        public static Links SetDataFromControlSocketFilter(this Filter_Sockets filterControl)
        {
            Links links = new Links();

            string min = filterControl.GetMin();
            string max = filterControl.GetMax();
            string r = filterControl.GetR();
            string g = filterControl.GetG();
            string b = filterControl.GetB();
            string w = filterControl.GetW();

            if (min != null)
                links.Min = min.ToLong();
            else
                links.Min = null;

            if (max != null)
                links.Max = max.ToLong();
            else
                links.Max = null;

            if (r != null)
                links.R = r.ToLong();
            else
                links.R = null;

            if (g != null)
                links.G = g.ToLong();
            else
                links.G = null;

            if (b != null)
                links.B = b.ToLong();
            else
                links.B = null;

            if (w != null)
                links.W = w.ToLong();
            else
                links.W = null;

            return links;
        }

        /// <summary>
        /// Gets a string between two other strings
        /// </summary>
        /// <param name="value">original string</param>
        /// <param name="a">start string</param>
        /// <param name="b">end string</param>
        /// <returns></returns>
        public static string Between(this string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }

        public static void DebugTable(this DataTable table)
        {
            Debug.WriteLine("--- DebugTable(" + table.TableName + ") ---");
            int zeilen = table.Rows.Count;
            int spalten = table.Columns.Count;

            // Header
            for (int i = 0; i < table.Columns.Count; i++)
            {
                string s = table.Columns[i].ToString();
                Debug.Write(String.Format("{0,-" + debugHeaderWidth + "} | ", s));
            }
            Debug.Write(Environment.NewLine);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                string s = "";

                for (int j = 0; j < (debugHeaderWidth + i + 1); j++)
                {
                    s += "-";
                }
                s += "|";
                Debug.Write(s);
            }
            Debug.Write(Environment.NewLine);

            // Data
            for (int i = 0; i < zeilen; i++)
            {
                DataRow row = table.Rows[i];
                //Debug.WriteLine("{0} {1} ", row[0], row[1]);
                for (int j = 0; j < spalten; j++)
                {
                    string s = row[j].ToString();
                    if (s.Length > debugHeaderWidth) s = s.Substring(0, debugHeaderWidth - 3) + "...";
                    Debug.Write(String.Format("{0,-" + debugHeaderWidth + "} | ", s));
                }
                Debug.Write(Environment.NewLine);
            }
            for (int i = 0; i < table.Columns.Count; i++)
            {
                string s = "";

                for (int j = 0; j < (debugHeaderWidth + i + 1); j++)
                {
                    s += "-";
                }
                s += "|";
                Debug.Write(s);
            }
            Debug.Write(Environment.NewLine);
        }

        public static bool CanConnect(string url)
        {
            Ping pinger = new Ping();
            try
            {
                PingReply pr = pinger.Send(url);
                if (pr.Status == IPStatus.Success)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if (pinger != null)
                    pinger.Dispose();
            }

            return false;
        }

        /// <summary>
        /// Removes part of a string starting by a keyword.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyword"></param>
        /// <param name="removeKeyword"></param>
        /// <returns></returns>
        public static string RemoveFrom(this string source, string keyword, bool removeKeyword)
        {
            int index = source.IndexOf(keyword);

            if (!removeKeyword)
                index += keyword.Length;

            return source.Remove(index, source.Length - index);
        }

        /// <summary>
        /// Removes part of the string from string:from to string:to
        /// </summary>
        /// <param name="source"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static string RemoveFromTo(this string source, string from, string to, int startOffset = 0)
        {
            if (source.Contains(from) && source.Contains(to))
            {
                int index = source.IndexOf(from) + startOffset;
                int index2 = source.IndexOf(to, index);

                source = source.Remove(index, (index2 - index) + 1);
            }

            return source;
        }

        public static bool IsUniqueMap(this string source)
        {
            string[] maps = {
                "Acton's Nightmare",
                "Caer Blaidd, Wolfpack's Den",
                "Death and Taxes",
                "Hall of Grandmasters",
                "Hallowed Ground",
                "Maelström of Chaos",
                "Mao Kun",
                "Oba's Cursed Trove",
                "Olmec's Sanctum",
                "Pillars of Arun",
                "Poorjoy's Asylum",
                "The Beachhead",
                "The Coward's Trial",
                "The Perandus Manor",
                "The Putrid Cloister",
                "The Twilight Temple",
                "The Vinktar Square",
                "Vaults of Atziri",
                "Whakawairua Tuahu"
            };
            foreach (string m in maps)
            {
                if (source.Contains(m))
                    return true;
            }
            return false;
        }

        public static string ToDiscriminator(this string source)
        {
            if (source.Contains("(War for the Atlas)"))
                return "warfortheatlas";
            else if (source.Contains("Atlas of Worlds"))
                return "atlasofworlds";
            else if (source.Contains("Original"))
                return "original";
            else if (source.Contains("The Awakening"))
                return "theawakening";

            return "";
        }

        #region StringTo...

        /// <summary>
        /// Try to convert string to boolean Returns false if it fails
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string source)
        {
            bool b = false;
            try
            {
                b = Convert.ToBoolean(source);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Could not convert to boolean : " + e);
            }
            return b;
        }

        /// <summary>
        /// Try to convert string to float
        /// Returns -1 if it fails
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static float ToFloat(this string source)
        {
            float f = -1.0f;
            try
            {
                f = Convert.ToSingle(source);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Could not convert to float : " + e);
            }
            return f;
        }

        /// <summary>
        /// Try to convert string to Int32
        /// Returns -1 if it fails
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int ToInt(this string source)
        {
            int i = -1;
            try
            {
                i = Convert.ToInt32(source);
            }
            catch (FormatException e)
            {
                Console.WriteLine("<ToInt> : Could not convert " + source + " to Int32 : " + e + "Input string : " + source);
            }
            return i;
        }

        /// <summary>
        /// Try to convert string to Long
        /// Returns -1 if it fails
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static long ToLong(this string source)
        {
            long i = 0;
            try
            {
                i = Convert.ToInt64(source);
            }
            catch (FormatException e)
            {
                Console.WriteLine("<ToLong>() : Could not convert string(" + source + ") to Int64 : " + e);
            }
            return i;
        }

        #endregion StringTo...
    }
}