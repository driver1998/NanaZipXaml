using Mile.Xaml;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static WinFormsApp1.NativeMethods;
namespace WinFormsApp1
{
    public partial class SettingForm : Form
    {
        private WindowsXamlHost xamlHost = new();
        public SettingForm()
        {
            InitializeComponent();

            this.Controls.Add(xamlHost);
            xamlHost.Dock = DockStyle.Fill;
            xamlHost.AutoSize = true;
            xamlHost.Child = new SettingWindowControl();

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