using System;

namespace NoamCurrencyExchange
{

    /* Couple class is an object that contains 3 parameters of an exchange rate couple:
     * Name of couple
     * Value of couple
     * Last update
     */

    class Couple
    {
        public string coupleName { get; set; }
        public double coupleValue { get; set; }
        public string time { get; set; }

        public Couple()
        {
            this.coupleName = "";
            this.coupleValue = 0.0;
            this.time = "";
        }

        public Couple(String name, double val, string now)
        {
            this.coupleName = name;
            this.coupleValue = val;
            this.time = now;
        }

        public string getName()
        {
            return this.coupleName;
        }

        public double getVal()
        {
            return this.coupleValue;
        }

        public string getTime()
        {
            return this.time;
        }
    }
}
