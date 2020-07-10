using PoE_Trade_Overlay.Queries;
using System;
using System.Data;

namespace PoE_Trade_Overlay
{
    public static class Ninja
    {
        public static CurrencyRates currencyRates;
        private const string url = "https://poe.ninja/api/Data/GetCurrencyOverview?league=";
        public static bool isEnabled;

        public static void Load(string league)
        {
            try
            {
                currencyRates = CurrencyRates.FromJson((string)QueryHelper.GetWebRequest(url + league));

                DataTable dt = new DataTable();
                dt.Columns.Add("currencyTypeName");
                dt.Columns.Add("chaosEquivalent");

                foreach (Line l in currencyRates.Lines)
                {
                    dt.Rows.Add(l.CurrencyTypeName, l.ChaosEquivalent);
                }
                Data.currencyRates = dt;
            }
            catch (Exception e)
            {
                Console.WriteLine("poeNinja.Load Exception : " + e.Message);
            }
        }
    }
}