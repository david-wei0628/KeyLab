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
    public partial class Form2 : Form
    {
        //CaptureClass CCType = new CaptureClass();
        private PictureBox pictureBox;

        public Form2()
        {
            InitializeComponent();

            InitializeStreaming();
        }

        /*private Bitmap CaptureScreen()
        {
            // 獲取螢幕的邊界
            Rectangle bounds = Screen.PrimaryScreen.Bounds;

            // 創建一個 Bitmap 來儲存截圖
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);

            // 使用 Graphics 來從螢幕擷取圖像
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return bitmap;
        }

        private Bitmap CaptureMouseArea(int width, int height)
        {
            // 獲取鼠標位置
            Point mousePosition = Cursor.Position;

            // 計算擷取區域的左上角位置
            int x = mousePosition.X - width / 2;
            int y = mousePosition.Y - height / 2;

            // 創建一個 Bitmap 來儲存截圖
            Bitmap bitmap = new Bitmap(width, height);

            // 使用 Graphics 來從螢幕擷取圖像
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(new Point(x, y), Point.Empty, new Size(width, height));
            }

            return bitmap;
        }*/

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            //Bitmap screenshot = CaptureScreen();
            //Bitmap screenshot = CCType.CaptureWindowsScreen();
            //Bitmap screenshot = CCType.CaptureMouseArea(200, 200);
            // 將截圖顯示在 PictureBox 中
            //pictureBox1.Image = screenshot;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pictureBox1 = new PictureBox { Dock = DockStyle.Fill };
            //buttonCapture = new Button { Text = "Capture", Dock = DockStyle.Top };
            //buttonCapture.Click += buttonCapture_Click;
            //Controls.Add(pictureBox1);
            //Controls.Add(buttonCapture);         

        }

        private void InitializeStreaming()
        {
            pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            //panel1.Controls.Add(pictureBox);

            Task.Run(() => StartStreaming());
        }

        private void StartStreaming()
        {
            while (true)
            {
                // 這裡加入取得視訊流影像的程式碼
                // 例如：Image frame = GetVideoFrame();

                // 更新 UI 執行緒上的 PictureBox
                pictureBox.Invoke((MethodInvoker)delegate
                {
                    pictureBox.Image = GetVideoFrame();
                });

                // 控制更新頻率
                System.Threading.Thread.Sleep(1000 / 30); // 每秒更新 30 次
            }
        }

        private Image GetVideoFrame()
        {
            // 模擬取得影像的程式碼
            return new Bitmap(320, 240);
        }
    }
}
