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
    public partial class Form3 : Form
    {
        private GlobalKeyboardHook_BPlane _globalKeyboardHook;
        private int countdownValue = 10;

        public Form3()
        {
            InitializeComponent();
            this.TopMost = true;

            countdownTimer = new Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;

            _globalKeyboardHook = new GlobalKeyboardHook_BPlane();
            _globalKeyboardHook.KeyPressed += GlobalKeyboardHook_KeyPressed;
            _globalKeyboardHook.SetHook();

            label1.Text = null;
            ComboBoxItem();
        }

        private void GlobalKeyboardHook_KeyPressed(object sender, KeyEventArgs e)
        {
            labelCountdown.Text = e.KeyData.ToString();
            //label1.Text += e.KeyData.ToString();

            //if (e.KeyCode == Keys.F1)
            if (e.KeyCode == Keys.C)
            {
                try
                {
                    // 執行輔助操作
                    //MessageBox.Show("F1 key pressed!");
                    if (countdownValue != 0)
                    {
                        countdownTimer.Stop();
                        countdownValue = 0;
                    }
                    CountTime();
                }
                catch
                {

                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _globalKeyboardHook.Unhook();
            base.OnFormClosing(e);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            CountTime();
            //countdownValue = 50;
            //labelCountdown.Text = countdownValue.ToString();
            //countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            //if (countdownValue > 0)
            //{
            //    countdownValue--;
            //    labelCountdown.Text = countdownValue.ToString();
            //}
            //else
            //{
            //    countdownTimer.Stop();
            //    labelCountdown.Text = "Time's up!";
            //}

            if (countdownValue > 0)
            {
                countdownValue--;
                //label1.Text = TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss +"); // Update the Label with the new timeLeft value
                //label1.Text = timeLeft.ToString(@"mm\:ss"); // Update the Label with the new timeLeft value
                try
                {
                    labelCountdown.Text = TimeSpan.FromSeconds(countdownValue).ToString(@"mm\:ss");
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
                labelCountdown.Text = "Time's up!";
                //SendKeys.Send("{F1}");
            }
        }

        private void CountTime()
        {
            countdownValue = Int32.Parse(comboBox1.Text);
            //labelCountdown.Text = countdownValue.ToString();
            labelCountdown.Text = TimeSpan.FromSeconds(countdownValue).ToString(@"mm\:ss");
            countdownTimer.Start();
        }

        private void ComboBoxItem()
        {
            comboBox1.Items.Add(60);
            //comboBox1.Items.Add(TimeSpan.FromSeconds(60).ToString(@"mm\:ss"));
            comboBox1.Items.Add(120);
            //comboBox1.Items.Add(TimeSpan.FromSeconds(120).ToString(@"mm\:ss"));
            comboBox1.Items.Add(300);
            //comboBox1.Items.Add(TimeSpan.FromSeconds(300).ToString(@"mm\:ss"));
            comboBox1.Items.Add(600);
            //comboBox1.Items.Add(TimeSpan.FromSeconds(600).ToString(@"mm\:ss"));

            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                textBox1.Text = e.KeyCode.ToString().ToUpper();
            }
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                textBox1.Text = e.KeyCode.ToString().Substring(1);
            }
            else if (e.KeyCode >= Keys.F1 && e.KeyCode <= Keys.F12)
            {
                textBox1.Text = e.KeyCode.ToString();
            }
            else
            {
                switch (e.KeyCode)
                {
                    default:
                        textBox1.Text = "UNKNOWN";
                        break;
                }

            }



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            //擋textbox的按鍵輸入
        }
    }
}
