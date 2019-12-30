using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var busyF = new BusyForm();
            busyF.Show();
            busyF.FormClosing += new FormClosingEventHandler(BuSyFormClosing);
            string result = await FiboAsync(10);
            busyF.Hide();
            MessageBox.Show(result.ToString());
            this.Enabled = true;
        }

        private async Task<string> FiboAsync(int n)
        {
            return await Task.Run<string>(() =>
            {
                Fibonacci.Fibo fibonacciService = new Fibonacci.Fibo();
                var result = fibonacciService.Fibonacci(10);
                return result;

            });
        }

        private void BuSyFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }


    }
}
