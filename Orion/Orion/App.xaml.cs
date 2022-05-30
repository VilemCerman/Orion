using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Orion
{
    public partial class App : Application
    {
        public class Globals
        {
            public static string LastViewedGraph;
            public static string[,] LastViewedData;
        }
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            Globals.LastViewedGraph = "";
            Globals.LastViewedData = DataSource.Data1;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
