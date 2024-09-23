using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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

    public class GlobalKeyboardHook
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;

        private Form1 form1;

        public GlobalKeyboardHook(Form1 form)
        {
            form1 = form;
        }

        public GlobalKeyboardHook()
        {
            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }

        ~GlobalKeyboardHook()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                
                form1 = new Form1();
                LabKeymode((Keys)vkCode);
                //Console.WriteLine(vkCode.ToString());
                UnhookWindowsHookEx(_hookID);

            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public void LabKeymode(object vKey)
        {
            //if (vKey.ToString() == "A")
            //{
            //    //SendKeys.Send("%{TAB}");
            //    string customText = "Hello, World!";
            //    // 使用 SendKeys.Send 方法來模擬按鍵輸入
            //    SendKeys.Send(customText);
            //}

            int TimeData = Form1.timeLeft;
            //int TimeData = form1.SharedTimeData;
            Console.WriteLine(TimeData);

            if (vKey.ToString() == /*"F1"*/"S" && TimeData == 0)
            {
                //form1.ATt();
                
                //MessageBox.Show(Form1.timeLeft.ToString());
            }
        }
    }

}
