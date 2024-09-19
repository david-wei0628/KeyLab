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
        }

        private void GlobalKeyboardHook_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                try
                {
                    // 執行輔助操作
                    //MessageBox.Show("F1 key pressed! to c");
                    labelCountdown.Text = "F1 KEYCODE to assdsa";
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
            countdownValue = 50;
            labelCountdown.Text = countdownValue.ToString();
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (countdownValue > 0)
            {
                countdownValue--;
                labelCountdown.Text = countdownValue.ToString();
            }
            else
            {
                countdownTimer.Stop();
                labelCountdown.Text = "Time's up!";
            }
        }
    }
}
