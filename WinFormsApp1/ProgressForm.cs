using Mile.Xaml;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static WinFormsApp1.NativeMethods;

namespace WinFormsApp1
{
    public partial class ProgressForm : Form
    {
        private WindowsXamlHost xamlHost = new();
        public ProgressForm()
        {
            InitializeComponent();

            this.Controls.Add(xamlHost);
            xamlHost.Dock = DockStyle.Fill;
            xamlHost.AutoSize = true;
            xamlHost.Child = new ProgressWindowControl();

            this.Text = "ÕýÔÚÌí¼Ó debian-12.0.0-amd64-netinst.iso";

            var options = new WTA_OPTIONS
            {
                dwMask = WTNCA_NODRAWCAPTION | WTNCA_NODRAWICON,
                dwFlags = WTNCA_NODRAWCAPTION | WTNCA_NODRAWICON
            };
            SetWindowThemeAttribute(this.Handle, WTA_NONCLIENT, ref options, Marshal.SizeOf(options));

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