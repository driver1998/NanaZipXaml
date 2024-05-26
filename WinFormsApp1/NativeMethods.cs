using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class NativeMethods
    {

        [StructLayout(LayoutKind.Sequential)]
        internal struct WTA_OPTIONS
        {
            public uint dwFlags;
            public uint dwMask;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }

        [DllImport("dwmapi.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttrubute, ref int pvAttribute, int cbAttribute);

        [DllImport("dwmapi.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS pMarInset);

        [DllImport("UxTheme.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern int SetWindowThemeAttribute(IntPtr hwnd, int eAttribute, ref WTA_OPTIONS pvAttribute, int cbAttribute);

        internal const int DWMWA_SYSTEMBACKDROP_TYPE = 38;
        internal const int DWMSBT_MAINWINDOW = 2;

        internal const int WTA_NONCLIENT = 1;
        internal const int WTNCA_NODRAWCAPTION = 0x1;
        internal const int WTNCA_NODRAWICON = 0x2;
        internal const int WTNCA_NOSYSMENU = 0x4;
    }
}
