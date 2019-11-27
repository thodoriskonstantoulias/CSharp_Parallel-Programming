using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitFormExample
{
    public partial class Form1 : Form
    {
        public int CalculateValue()
        {
            Thread.Sleep(5000);
            return 123;
        }
        public Task<int> CalculateValueAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return 123;
            });              
        }
        public async Task<int> CalculateValueAsyncBetterMethod()
        {
            await Task.Delay(5000);
            return 123;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //The following regulat method blocks the UI
            //int n = CalculateValue();
            //lblresult.Text = n.ToString();

            //Using asynchronous method give the UI freedom to move etc.
            //var calculation = CalculateValueAsync();
            //calculation.ContinueWith(t =>
            //{
            //    lblresult.Text = t.Result.ToString();
            //},TaskScheduler.FromCurrentSynchronizationContext());

            //Better method for asynchronous programming
            int value = await CalculateValueAsyncBetterMethod();
            lblresult.Text = value.ToString();

            //And now let's play
            await Task.Delay(5000);
            using(var wc = new WebClient())
            {
                string data = await wc.DownloadStringTaskAsync("http://google.com/robots.txt");
                lblresult.Text = data.Split('\n')[0].Trim();
            }
        }
    }
}
