using System;

namespace NoamCurrencyExchange
{
    /* FinanceFetcher interface provides properties and methods for implementing currency exchange APIs.
     * This interface ment to help implement other web API services.
     * In this projects the classes that implement this interface are:
     * OpenExRatesAPI
     * FixerAPI
     */

    interface FinanceFetcher
    {
        string APIURL { get; set; }
        void fetchCurrency();
        void saveDataToFile(string data, DateTime time);
    }
}
