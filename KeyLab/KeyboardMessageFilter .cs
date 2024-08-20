using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLab
{
    public class KeyboardMessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            const int WM_KEYDOWN = 0x0100;
            if (m.Msg == WM_KEYDOWN)
            {
                Keys key = (Keys)m.WParam.ToInt32();
                // 在這裡處理鍵盤事件
                Console.WriteLine("Key Pressed: " + key.ToString());
                return true; // 攔截訊息
            }
            return false; // 不攔截訊息
        }
    }
}
