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
        public Timer countdownTimer;
        //public static int timeLeft;
        private int timeLeft;
        private GlobalKeyboardHook _globalKeyboardHook;
        private BackgroundWorker worker = new BackgroundWorker();
        //private int TimeMemory = 600;

        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;//視窗最上層
            this.FormBorderStyle = FormBorderStyle.None;//無邊框

            TitleSetting titleBarSetting = new TitleSetting(this, "自定義標題欄");
            this.Controls.Add(titleBarSetting);///自定義標題欄設定

            this.TransparencyKey = Color.Lime;
            PlaneSetting planeSetting = new PlaneSetting();
            planeSetting.Parent = this; // 確保 Panel 的父控件是 Form
            this.Controls.Add(planeSetting);

            this.KeyPreview = true;
            //Application.AddMessageFilter(new KeyboardMessageFilter());

            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);

            _globalKeyboardHook = new GlobalKeyboardHook();//鍵盤訊號擷取

            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // Interval set to 1 second
            countdownTimer.Tick += CountdownTimer_Tick;

        }

        public int SharedTimeData
        {
            get { return timeLeft; }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //label2.Text = e.KeyData.ToString();

            //if (e.KeyData.ToString() == "S")
            //{
            //    //ATt();
            //}
        }

        public void CountdownTimer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine(SharedTimeData.ToString());
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
                //SendKeys.Send("{F1}");
            }

            if (timeLeft == 5)
            {
                //label2.Text = ActiveForm.ToString();
                //KeyTest();
                Console.WriteLine(label2.Text);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timeLeft = 600; // Set the countdown time in seconds
                            //Console.WriteLine(timeLeft);
                            //label1.Text = "10:00" /*+ timeLeft.ToString()*/;
            try
            {
                countdownTimer.Start();
                //ATt();
            }
            catch { }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //countdownTimer.Stop();
            //timeLeft = 600; // Reset the countdown time
            //label1.Text = "10:00"; // Reset the Label text
            ////Console.WriteLine(Form.ActiveForm);
            worker.Dispose();
        }

        public void ATt()
        {
            countdownTimer.Dispose();
            timeLeft = 10; // Set the countdown time in seconds
            label1.Text = "10:00" /*+ timeLeft.ToString()*/;
            try
            {
                countdownTimer.Start();
            }
            catch { }
        }

        public void KeyTest()
        {
            label2.Text = label2.Text + timeLeft.ToString();
            try
            {
                label2.Invoke(new Action(() => label2.Text = timeLeft.ToString()));
            }
            catch { }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("A");
            if (timeLeft == 5)
            {
                Console.WriteLine("5A5");

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //MessageBox.Show(":");
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            label2.Text = timeLeft.ToString();

            timeLeft = 10;
            try
            {
                countdownTimer.Start();
            }
            catch { }
            //worker.RunWorkerAsync();

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("BKR");
            if (e.Error == null && !e.Cancelled)
            {
                Console.WriteLine("Test");
                label2.Text = timeLeft.ToString();
            }
        }
    }
}
