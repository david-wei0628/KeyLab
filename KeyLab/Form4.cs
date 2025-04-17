using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyLab
{
    public partial class Form4 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left; public int Top; public int Right; public int Bottom;
        }

        private PictureBox pictureBox;
        private ComboBox windowSelector;
        private Timer timer;
        public Form4()
        {
            InitializeComponent(); pictureBox = new PictureBox { Dock = DockStyle.Fill };
            windowSelector = new ComboBox { Dock = DockStyle.Top };
            windowSelector.Items.AddRange(new string[] { "Untitled - Notepad", "Calculator", "YourAppWindowTitle" });
            windowSelector.SelectedIndexChanged += WindowSelector_SelectedIndexChanged; Controls.Add(pictureBox);
            Controls.Add(windowSelector);
            timer = new Timer { Interval = 1000 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void WindowSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CaptureWindow(windowSelector.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (windowSelector.SelectedItem != null)
            {
                CaptureWindow(windowSelector.SelectedItem.ToString());
            }
        }

        private void CaptureWindow(string windowTitle)
        {
            IntPtr hWnd = FindWindow(null, windowTitle);
            if (hWnd != IntPtr.Zero)
            {
                if (GetWindowRect(hWnd, out RECT rect))
                {
                    int width = rect.Right - rect.Left;
                    int height = rect.Bottom - rect.Top;
                    Bitmap bitmap = new Bitmap(width, height);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(rect.Left, rect.Top, 0, 0, new Size(width, height));
                    }
                    pictureBox.Image?.Dispose(); pictureBox.Image = bitmap;
                }
                else
                {
                    MessageBox.Show("無法獲取視窗大小");
                }
            }
            else
            {
                MessageBox.Show("未找到指定視窗");
            }
        }
    }
}
