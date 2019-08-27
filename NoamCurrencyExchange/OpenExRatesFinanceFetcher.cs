using System;
using System.Net;

namespace NoamCurrencyExchange
{
    /* OpenExRatesFinanceFetcher class implements the FinanceFetcher interface.
     * fetchCurrency method fetches data from Open Exchange Rates API, and execute the saveDataToFile method.
     * saveDataToFile method saves the JSON received from the API to one file, and the time the JSON was feched in a second file.
     */

    class OpenExRatesFinanceFetcher : FinanceFetcher
    {
   
        public string APIURL { get; set; }

        public OpenExRatesFinanceFetcher()
        {
            this.APIURL = "https://openexchangerates.org/api/latest.json?app_id=81e2d61b850948d5868e6405abb15d65";
            fetchCurrency();
        }

        public void fetchCurrency()
        {
            string json = new WebClient().DownloadString(this.APIURL);
            DateTime now = DateTime.Now;
            saveDataToFile(json, now);
        }

        public void saveDataToFile(string data, DateTime time)
        {
            System.IO.File.WriteAllText(@"USD_Rates.txt", data); // Saving the json to a folder as a txt file.
            System.IO.File.WriteAllText(@"USD_time.txt", time.ToString());
        }

    }
}
