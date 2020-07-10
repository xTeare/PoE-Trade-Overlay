using System;
using System.IO;
using System.Net;

namespace PoE_Trade_Overlay.Queries
{
    public static class QueryHelper
    {
        public static string GetDefaultQuery()
        {
            return File.ReadAllText("DefaultQuery.txt");
        }

        public static QueryResult GetQueryResults()
        {
            return null;
        }

        /// <summary>
        /// Posts a request to server
        /// eg. to get Search Results
        /// </summary>
        /// <param name="url"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        public static object PostWebRequest(string url, string post)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(post);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("QueryHelper::PostWebRequest Exception : " + e.Message);
            }

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine("QueryHelper::PostWebRequest WebException : " + e.Message);
                return null;
            }
            if (response != null)
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            else
            {
                return null;
            }
        }

        public static object GetWebRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0";

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine("QueryHelper::GetGETResponse() WebException : " + e.Message);
                return null;
            }
            if (response != null)
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            else
            {
                return null;
            }
        }
    }
}