using System;
using System.IO;
using System.Net;
using System.Text;

namespace PoE_Trade_Overlay
{
    public static class Statistics
    {
        public static void PostStat(string value, string type)
        {
            if (Config.GetEntryB("Send anonymous search statistics"))
                Console.WriteLine(Request(type, value));
        }

        private static string Request(string type, string value)
        {
            string url = "https://poeto.net/api/set/statistics.php";
            byte[] byteArray = Encoding.UTF8.GetBytes("type=" + type + "&value=" + value + "&league=" + Config.GetEntry("League"));
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ContentLength = byteArray.Length;
                using (Stream webpageStream = webRequest.GetRequestStream())
                {
                    webpageStream.Write(byteArray, 0, byteArray.Length);
                }
                HttpWebResponse response = null;

                response = (HttpWebResponse)webRequest.GetResponse();
                if (response != null)
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Statistics::Request(type:{type}, value:{value}) Exception : " + e.Message);
            }

            return "";
        }
    }
}