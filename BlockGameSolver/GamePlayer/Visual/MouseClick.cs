using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BlockGameSolver.GamePlayer.Visual
{
    internal class MouseClick
    {
        private static readonly UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private static readonly UInt32 MOUSEEVENTF_LEFTUP = 0x0004;

        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

        public static void SendClick(Point location)
        {
            Cursor.Position = location;
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new IntPtr());
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new IntPtr());
        }
    }
}