using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Orion
{
    class ThemeManager
    {
        public enum Themes
        {
            Light,
            Dark
        }

        public static string BackgroundColor = "#EEF2FE";

        public static string CardBackgroundColor = "#FFFFFF";

        public static string TextColor = "#4A219B";

        public static string graphTextColor = "#4A219B";

        public static Themes CurrentTheme = Themes.Light;

        public static bool DarkSwitchOn = false;

        public static void SwitchTheme()
        {
            switch (CurrentTheme)
            {
                case Themes.Light:
                    {
                        CurrentTheme = Themes.Dark;
                        break;
                    }
                case Themes.Dark:
                    {
                        CurrentTheme = Themes.Light;
                        break;
                    }
            }
            LoadTheme();
        }
        public static void LoadTheme()
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            switch (CurrentTheme)
            {
                case Themes.Light:
                    {
                        Application.Current.Resources.MergedDictionaries.Add(new ThemeResources.LightTheme());
                        BackgroundColor = "#EEF2FE";
                        CardBackgroundColor = "#FFFFFF";
                        TextColor = "#4A219B";
                        graphTextColor = "#000000";
                        break;
                    }
                case Themes.Dark:
                    {
                        Application.Current.Resources.MergedDictionaries.Add(new ThemeResources.DarkTheme());
                        BackgroundColor = "#4A219B";
                        CardBackgroundColor = "#26245F";
                        TextColor = "#FFFFFF";
                        graphTextColor = "#FFFFFF";
                        break;
                    }
            }

        }
    }
}
