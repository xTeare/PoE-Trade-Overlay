using System.Collections.Generic;
using System.Data;
using System.IO;

namespace PoE_Trade_Overlay
{
    public static class Config
    {
        public static DataTable values;
        public static string path = "config.ini";

        public static string GetID()
        {
            return File.ReadAllText("id");
        }

        public static void Load()
        {
            values = new DataTable();
            values.Columns.Add("Name");
            values.Columns.Add("Value");

            if (File.Exists(path))
            {
                IEnumerable<string> lines = File.ReadLines(path);
                foreach (string line in lines)
                {
                    string[] strings = line.Split('=');
                    values.Rows.Add(strings[0], strings[1]);
                }
            }
        }

        /// <summary>
        /// Sets a value of a DataRow, found by the DataRow's name
        /// </summary>
        /// <param name="name">Name of the DataRow</param>
        /// <param name="value">Value to set in the found DataRow</param>
        public static void SetEntry(string name, string value)
        {
            foreach (DataRow dr in values.Rows)
            {
                if (dr[0].ToString() == name)
                {
                    dr[1] = value;
                    return; // End loop so we save some iterations
                }
            }
        }

        /// <summary>
        /// Returns a value of a DataRow, found by the DataRow's name
        /// </summary>
        /// <param name="name">Name of the DataRow</param>
        /// <returns></returns>
        public static string GetEntry(string name)
        {
            foreach (DataRow dr in values.Rows)
            {
                if (dr[0].ToString() == name)
                    return dr[1].ToString();
            }
            return "";
        }

        public static bool GetEntryB(string name)
        {
            foreach (DataRow dr in values.Rows)
            {
                if (dr[0].ToString() == name)
                    return dr[1].ToString().ToBoolean();
            }
            return false;
        }

        public static void Save(bool reload = false)
        {
            List<string> lines = new List<string>();
            foreach (DataRow dr in values.Rows)
            {
                lines.Add(dr[0] + "=" + dr[1]);
            }
            File.WriteAllLines(path, lines);
            if (reload)
            {
                Load();
            }
        }
    }
}