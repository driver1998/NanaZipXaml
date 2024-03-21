using Mile.Xaml;
using Mile.Xaml.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace WinFormsApp1
{
    public partial class App : Application
    {
        [ThreadStatic]
        private static WindowsXamlManager? XamlManager;

        public App()
        {
            if (XamlManager == null)
            {
                XamlManager = WindowsXamlManager.InitializeForCurrentThread();
            }

            Window.Current.GetInterop().TransparentBackground = true;
            this.InitializeComponent();
        }

        public void Close()
        {
            this.Exit();

            if (XamlManager != null)
            {
                XamlManager.Dispose();
                XamlManager = null;
            }
        }
    }
}
