using System;
using System.Threading;
using System.Windows.Forms;


namespace NoamCurrencyExchange
{
    /* MainUI class runs the user interface which provide:
     * Live data updates every 3 seconds
     * Button for manual update the data when ever the user like.
     * MainUI constractor initialized its properties: 
     * FixerFinanceFetcher object
     * OpenExRatesFinanceFetcher object
     * FileReader object
     * Also - triggers a thread which updates the data every 3 seconds by calling the runUpdate method
     * runUpdate method uses 3 threads (2 for fetching data (and writing to files) from 2 different APIs, and 1 for reading from the file.),
     * Thaen, the method updates the data in the UI.
     * button1_Click method calls the runUpdate method.
     * 
     */

    public partial class MainUI : Form
    {
        private FixerFinanceFetcher fixerAPI { get; set; }
        private OpenExRatesFinanceFetcher openERAPI { get; set; }
        private FileReader fileReader { get; set; }


        public MainUI()
        {
            InitializeComponent();
            button1.Text = "Update Rates";
            this.fixerAPI = new FixerFinanceFetcher();
            this.openERAPI = new OpenExRatesFinanceFetcher();
            this.fileReader = new FileReader();
            Thread trigger = new Thread(() =>
            {
                triggerIntervalUpdate();
            });
            trigger.IsBackground = true;
            trigger.Start();
        }

        public void triggerIntervalUpdate()
        {
            while (true)
            {
                Thread.Sleep(3000);
                runUpdate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            runUpdate();
        }

        public void runUpdate()
        {
            Thread EUR = new Thread(() =>
            {
                this.fixerAPI.fetchCurrency();
            });
            EUR.IsBackground = true;
            EUR.Start();
            EUR.Join();

            Thread USD = new Thread(() =>
            {
                this.openERAPI.fetchCurrency();
            });
            USD.IsBackground = true;
            USD.Start();
            USD.Join();

            Thread read = new Thread(() =>
            {
                this.fileReader.readData();
            });
            read.IsBackground = true;
            read.Start();
            read.Join();

            label4.Text = this.fileReader.getEURJPY().getName();
            label5.Text = this.fileReader.getEURJPY().getVal().ToString();
            label6.Text = this.fileReader.getEURJPY().getTime();

            label7.Text = this.fileReader.getEURUSD().getName();
            label8.Text = this.fileReader.getEURUSD().getVal().ToString();
            label9.Text = this.fileReader.getEURUSD().getTime();

            label13.Text = this.fileReader.getGBPEUR().getName();
            label14.Text = this.fileReader.getGBPEUR().getVal().ToString();
            label15.Text = this.fileReader.getGBPEUR().getTime();

            label19.Text = this.fileReader.getUSDILS().getName();
            label20.Text = this.fileReader.getUSDILS().getVal().ToString();
            label21.Text = this.fileReader.getUSDILS().getTime();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}
