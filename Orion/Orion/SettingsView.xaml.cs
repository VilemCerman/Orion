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
    public partial class SettingsView : ContentView
    {
        private static bool changesMade = false;
        public SettingsView()
        {
            InitializeComponent();

            if (ThemeManager.DarkSwitchOn)
            {
                ThemeSwitch.Source = @"Images\Switch_to_dark.svg";
            }
            else
            {
                ThemeSwitch.Source = @"Images\Switch_to_light.svg";
            }
        }
        private async void BackBtn_Tapped(object sender, EventArgs e)
        {
            if (changesMade)
            {
                await Navigation.PushModalAsync(new DashBoardPage());
                ThemeManager.LoadTheme();
                changesMade = false;
            }
            else
            {
                SettingsTxt.TranslateTo(0, 0, 0);
                await SettingsContent.FadeTo(0, 200);
                SettingsCView.IsVisible = false;
            }
        }
        private void SwitchTheme_Tapped(object sender, EventArgs e)
        {
            changesMade = true;
            if (ThemeManager.DarkSwitchOn)
            {
                ThemeSwitch.Source = @"Images\Switch_to_light.svg";
                ThemeManager.DarkSwitchOn = false;
            }
            else
            {
                ThemeSwitch.Source = @"Images\Switch_to_dark.svg";
                ThemeManager.DarkSwitchOn = true;
            }
            ThemeManager.SwitchTheme();
        }
    }
}