using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyLab
{
    public class GlobalKeyboardHook_BPlane
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;

        public event EventHandler<KeyEventArgs> KeyPressed;

        public GlobalKeyboardHook_BPlane()
        {
            _proc = HookCallback;
        }

        public void SetHook()
        {
            _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, IntPtr.Zero, 0);
        }

        public void Unhook()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                KeyPressed?.Invoke(this, new KeyEventArgs((Keys)vkCode));
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}
