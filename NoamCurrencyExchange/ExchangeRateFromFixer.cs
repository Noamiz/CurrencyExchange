using System.Collections.Generic;

namespace NoamCurrencyExchange
{
    /* ExchangeRateFromFixer object contains the data (JSON) we fetch from Fixer API.
     * 
     */

    class ExchangeRateFromFixer
    {
        public bool success { get; set; }
        public long timestamp { get; set; }
        public string base1 { get; set; }
        public string date { get; set; }
        public Dictionary<string, double> rates { get; set; }
    }
}
