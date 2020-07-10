using System.Collections.Generic;

namespace PoE_Trade_Overlay.Queries
{
    /// <summary>
    /// Recieves a SearchResult query and processes its content
    /// </summary>
    public class SearchResultManager
    {
        private SearchResults sr;

        private List<string> results = new List<string>();
        public string QueryID;

        private const string fetchURL = "https://www.pathofexile.com/api/trade/fetch/";

        public string query;
        public bool isLoading;
        public string pseudos;

        public SearchResultManager(SearchResults _sr)
        {
            sr = _sr;
            QueryID = sr.Id;

            foreach (string s in sr.Result)
                results.Add(s);
        }

        /// <summary>
        /// Get the first 10 emelemts from the search result (List<string> results), processes them to the fetch url and removes them afterwards
        /// </summary>
        /// <param name="pseudos"></param>
        /// <returns></returns>
        public string GetFetchURL(string pseudos = "")
        {
            int from = 0;
            int to = 10;
            string url = "";
            List<string> elementsToRemove = new List<string>();

            if (to > results.Count)
                to = results.Count;

            if (results.Count <= 0)
                return "";

            for (int i = from; i < to; i++)
            {
                url += results[i] + ((i == to - 1) ? "" : ",");
                elementsToRemove.Add(results[i]);
            }
            System.Console.WriteLine(pseudos);

            url += "?query=" + QueryID;


            //&pseudos[]=pseudo.pseudo_total_cold_resistance&pseudos[]=pseudo.pseudo_total_lightning_resistance
            if (!string.IsNullOrEmpty(pseudos))
            {
                string[] splits = pseudos.Split(new char[] { '|' }, System.StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in splits)
                {
                    System.Console.WriteLine(s);
                    url += "&pseudos[]=" + s;
                }

            }

            

            // Removes all elemenets previously added to the fetch url
            foreach (string s in elementsToRemove)
                results.Remove(s);

            return fetchURL + url;
        }
    }
}