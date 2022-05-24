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
    public partial class DashBoardPage : ContentPage
    {
        private bool isSideMenuOut = false;
        public DashBoardPage()
        {
            InitializeComponent();
            sideMenuGrid.TranslateTo(-1500, 0, 0);
            sideMenu.sideListView.ItemSelected += OnSelectedItem;
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutMenuItem;
            if (item != null)
            {
                Navigation.PushModalAsync((Page)Activator.CreateInstance(item.TargetPage));
            }
        }

        private void SideMenuBtn_Tapped(object sender, EventArgs e)
        {
            if (isSideMenuOut)
            {
                sideMenuBtn.TranslateTo(0, 0, 400, Easing.SinInOut);
                sideMenuGrid.TranslateTo(-1500, 0, 400, Easing.CubicIn);
                isSideMenuOut = false;
            }
            else
            {
                sideMenuBtn.TranslateTo(200, 0, 400, Easing.SinOut);
                sideMenuGrid.TranslateTo(0, 0, 400, Easing.CubicOut);
                isSideMenuOut = true;
            }
        }
        private void GraphBtn_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
    }
}