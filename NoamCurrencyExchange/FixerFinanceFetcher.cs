using System;
using System.Net;

namespace NoamCurrencyExchange
{
    /* FixerFinanceFetcher class implements the FinanceFetcher interface.
     * fetchCurrency method fetches data from Fixer API, and execute the saveDataToFile method.
     * saveDataToFile method saves the JSON received from the API to one file, and the time the JSON was feched in a second file.
     * 
     */

    class FixerFinanceFetcher : FinanceFetcher
    {

        public string APIURL { get; set; }
        

        public FixerFinanceFetcher()
        {
            this.APIURL = "http://data.fixer.io/api/latest?access_key=db0cc28eedebacdc82ab60403712eb5c&format=1";
        }

        public void fetchCurrency()
        {
            string json = new WebClient().DownloadString(this.APIURL);
            DateTime now = DateTime.Now;
            saveDataToFile(json, now);
        }

        public void saveDataToFile(string data, DateTime time)
        {
            System.IO.File.WriteAllText(@"EUR_Rates.txt", data); // Saving the json to a folder as a txt file.
            System.IO.File.WriteAllText(@"EUR_time.txt", time.ToString());
        }

    }
}
