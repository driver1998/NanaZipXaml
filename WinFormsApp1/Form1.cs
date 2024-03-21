using Mile.Xaml;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        [DllImport("dwmapi.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttrubute, ref int pvAttribute, int cbAttribute);

        [DllImport("dwmapi.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS pMarInset);

        private const int DWMWA_SYSTEMBACKDROP_TYPE = 38;

        private const int DWMSBT_MAINWINDOW = 2;

        [StructLayout(LayoutKind.Sequential)]
        private struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }

        private WindowsXamlHost xamlHost = new();
        public Form1()
        {
            InitializeComponent();

            this.Controls.Add(xamlHost);
            xamlHost.Dock = DockStyle.Fill;
            xamlHost.AutoSize = true;
            xamlHost.Child = new MainWindowControl();

            this.Text = "";
            this.ShowIcon = false;

            int value = DWMSBT_MAINWINDOW;
            DwmSetWindowAttribute(this.Handle, DWMWA_SYSTEMBACKDROP_TYPE, ref value, Marshal.SizeOf(value));


            var margins = new MARGINS()
            {
                cxLeftWidth = -1,
                cxRightWidth = -1,
                cyTopHeight = -1,
                cyBottomHeight = -1,
            };
            DwmExtendFrameIntoClientArea(this.Handle, ref margins);

        }
    }
}