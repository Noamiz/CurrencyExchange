using System;
using Newtonsoft.Json;

namespace NoamCurrencyExchange
{
    /* FileReader class reads from 2 text files for each web service we decide to implement.
     * in this case total of 4 text files:
     * 1 file with the updated time from fixer web service, and 1 for the JSON.
     * 1 file with the updated time from OER web service, and 1 for the JSON.
     */

    class FileReader
    {

        public Couple EURJPY { get; set; }
        public Couple EURUSD { get; set; }
        public Couple GBPEUR { get; set; }
        public Couple USDILS { get; set; }

        public FileReader()
        {
            this.EURJPY = new Couple();
            this.EURUSD = new Couple();
            this.GBPEUR = new Couple();
            this.USDILS = new Couple();
        }

        // readData function receive relevant data from the files and stores it in the class properties.
        public void readData()
        {
            string jsonFixer = System.IO.File.ReadAllText(@"EUR_Rates.txt");
            string nowFixer = System.IO.File.ReadAllText(@"EUR_time.txt");
            string jsonOER = System.IO.File.ReadAllText(@"USD_Rates.txt");
            string nowOER = System.IO.File.ReadAllText(@"USD_time.txt");
            ExchangeRateFromFixer EUR_Rates = JsonConvert.DeserializeObject<ExchangeRateFromFixer>(jsonFixer);
            this.EURJPY = new Couple("EUR/JPY", EUR_Rates.rates["JPY"], nowFixer);
            this.EURUSD = new Couple("EUR/USD", EUR_Rates.rates["USD"], nowFixer);
            double GBP_EUR = (1 / EUR_Rates.rates["GBP"]);
            GBP_EUR = Math.Round(GBP_EUR, 6);
            this.GBPEUR = new Couple("GBP/EUR", GBP_EUR, nowFixer);

            ExchangeRateFromOER USD_Rates = JsonConvert.DeserializeObject<ExchangeRateFromOER>(jsonOER);
            this.USDILS = new Couple("USD/ILS", USD_Rates.rates["ILS"], nowOER);
        }

        public Couple getEURJPY()
        {
            return this.EURJPY;
        }

        public Couple getEURUSD()
        {
            return this.EURUSD;
        }

        public Couple getGBPEUR()
        {
            return this.GBPEUR;
        }

        public Couple getUSDILS()
        {
            return this.USDILS;
        }

    }
}
