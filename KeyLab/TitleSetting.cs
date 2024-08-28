using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyLab
{
    public class TitleSetting : Panel
    {
        private Label titleLabel;
        private Button closeButton;
        private Form parentForm;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public TitleSetting(Form parent, string title)
        {
            parentForm = parent;
            this.Size = new Size(parentForm.Width, 30); // 設置標題欄高度
            this.BackColor = Color.Purple;
            this.Dock = DockStyle.Top;

            titleLabel = new Label
            {
                Text = title,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            closeButton = new Button
            {
                Text = "X",
                ForeColor = Color.White,
                BackColor = Color.Red,
                Dock = DockStyle.Right,
                Width = 30,
                FlatStyle = FlatStyle.Flat
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += CloseButton_Click;

            this.Controls.Add(titleLabel);
            this.Controls.Add(closeButton);

            //// 添加拖動功能
            //this.MouseDown += TitleBar_MouseDown;
            //this.MouseMove += TitleBar_MouseMove;
            //this.MouseUp += TitleBar_MouseUp;

            titleLabel.MouseDown += TitleBar_MouseDown;
            titleLabel.MouseMove += TitleBar_MouseMove;
            titleLabel.MouseUp += TitleBar_MouseUp;

            //closeButton.MouseDown += TitleBar_MouseDown;
            //closeButton.MouseMove += TitleBar_MouseMove;
            //closeButton.MouseUp += TitleBar_MouseUp;

        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = parentForm.Location;
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                parentForm.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            parentForm.Close();
        }
    }

    public class PlaneSetting : Panel
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_LAYERED = 0x80000;
        private const int LWA_ALPHA = 0x2;

        public PlaneSetting()
        {
            //this.Size = new Size(200, 1200);
            //this.BackColor = Color.FromArgb(255, 255, 0, 0); // 半透明白色

            //SetWindowLong(this.Handle, GWL_EXSTYLE, GetWindowLong(this.Handle, GWL_EXSTYLE) | WS_EX_LAYERED);
            //SetLayeredWindowAttributes(this.Handle, 0, 255, LWA_ALPHA);
        }
    }
}