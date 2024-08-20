using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLab
{
    public partial class Form1 : Form
    {
        private Timer countdownTimer;
        private int timeLeft;
        private GlobalKeyboardHook _globalKeyboardHook;

        public Form1()
        {
            InitializeComponent();

            Application.AddMessageFilter(new KeyboardMessageFilter());
            _globalKeyboardHook = new GlobalKeyboardHook();

            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // Interval set to 1 second
            countdownTimer.Tick += CountdownTimer_Tick;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            label2.Text = e.KeyData.ToString();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                //label1.Text = TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss +"); // Update the Label with the new timeLeft value
                //label1.Text = timeLeft.ToString(@"mm\:ss"); // Update the Label with the new timeLeft value
                try
                {
                    label1.Text = TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss");
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else
            {
                countdownTimer.Stop();
                label1.Text = "Time's up!";
                SendKeys.Send("A");
                //SendKeys.Send("{F1}");
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timeLeft = 20; // Set the countdown time in seconds
            //label1.Text = "10:00" /*+ timeLeft.ToString()*/;
            countdownTimer.Start();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            countdownTimer.Stop();
            timeLeft = 20; // Reset the countdown time
            label1.Text = "00:20"; // Reset the Label text
        }

    }
}
