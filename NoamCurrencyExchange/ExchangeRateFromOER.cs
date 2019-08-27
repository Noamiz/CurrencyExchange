using System.Collections.Generic;

namespace NoamCurrencyExchange
{
    /* ExchangeRateFromOER object contains the data (JSON) we fetch from Open exchange rate API.
    * 
    */

    class ExchangeRateFromOER
    {
        public string disclaimer { get; set; }
        public string license { get; set; }
        public long timestamp { get; set; }
        public string base1 { get; set; }
        public Dictionary<string, double> rates { get; set; }
    }
}
