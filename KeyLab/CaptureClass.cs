using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace KeyLab
{
    public class CaptureClass
    {
        public Bitmap CaptureScreen()
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
        public Bitmap CaptureWindowsScreen()
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

        public Bitmap CaptureMouseArea(int width, int height)
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
        }
    }
}
