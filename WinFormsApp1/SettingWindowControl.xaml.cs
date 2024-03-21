using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace WinFormsApp1
{
    public partial class SettingWindowControl : UserControl
    {
        public SettingWindowControl()
        {
            this.InitializeComponent();

            var firstItem = NaviView.MenuItems[0] as NavigationViewItemBase;
            NaviView.SelectedItem = firstItem;

            Type navPageType = Type.GetType(firstItem?.Tag.ToString());
            ContentFrame.Navigate(navPageType, null, null);
        }

        private void NaviView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer != null)
            {
                Type navPageType = Type.GetType(args.InvokedItemContainer.Tag.ToString());
                NavView_Navigate(navPageType, args.RecommendedNavigationTransitionInfo);
            }
        }
        private void NavView_Navigate(Type navPageType,NavigationTransitionInfo transitionInfo)
        {            
            Type preNavPageType = ContentFrame.CurrentSourcePageType;
            if (navPageType is not null && !Type.Equals(preNavPageType, navPageType))
            {
                ContentFrame.Navigate(navPageType, null, transitionInfo);
            }
        }
    }
}
