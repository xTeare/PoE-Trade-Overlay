using System;
using System.IO;
using System.Net;
using System.Text;

namespace PoE_Trade_Overlay
{
    public static class Voting
    {
        public static int GetVotes(string name)
        {
            string votes = Request(name, Constants.CheckURL);
            Console.WriteLine(votes);
            return 0;
        }

        public static int Vote(string voter, string voted)
        {
            string ret = Request(voted, Constants.VoteURL, voter);
            Console.WriteLine(ret);
            return 0;
        }

        private static string Request(string voted, string url, string voter = "")
        {
            byte[] byteArray = Encoding.UTF8.GetBytes((voter == "") ? "voted=" + voted : "voted=" + voted + "&voter=" + voter);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return "";
        }
    }
}