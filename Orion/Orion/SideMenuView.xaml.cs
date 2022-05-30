using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Orion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuView : ContentView
    {
        public bool isSideMenuOut = false;
        public SideMenuView()
        {
            InitializeComponent();
            sideListView.ItemSelected += OnSelectedItem;
            sideMenu.TranslateTo(-1500, 0, 0);
        }
        public async void SideMenuBtn_Tapped(object sender, EventArgs e)
        {
            if (isSideMenuOut)
            {
                sideMenuBtn.TranslateTo(0, 0, 400, Easing.SinInOut);
                await sideMenu.TranslateTo(-1500, 0, 400, Easing.CubicIn);
                sideMenu.IsVisible = false;
                isSideMenuOut = false;
                InputTransparent = true;
            }
            else
            {
                sideMenu.IsVisible = true;
                sideMenuBtn.TranslateTo(200, 0, 400, Easing.SinOut);
                sideMenu.TranslateTo(0, 0, 400, Easing.CubicOut);
                isSideMenuOut = true;
            }
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutMenuItem;
            if (item != null)
            {
                if (item.Title.ToString() == "SETTINGS")
                {
                    Settings.SettingsCView.IsVisible = true;
                    sideListView.SelectedItem = null;
                    Settings.SettingsContent.FadeTo(1, 100);
                    Settings.SettingsTxt.TranslateTo(0, -130, 300, Easing.CubicOut);
                }
                else
                    Navigation.PushModalAsync((Page)Activator.CreateInstance(item.TargetPage));
            }
        }
    }
}