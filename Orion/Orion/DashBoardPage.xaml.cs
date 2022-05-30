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
        public DashBoardPage()
        {
            InitializeComponent();

            if (ThemeManager.DarkSwitchOn)
            {
                HomeBtn.Source = @"Images\dark_home_btn.svg";
                GraphBtn.Source = @"Images\dark_graph_btn_inactive.svg";
            }
        }

        private void Graph_Tapped(object sender, EventArgs e)
        {
            Card card = (Card)sender;
            CardList.IsVisible = false;
            CardDetail cd = new CardDetail(card.GraphType, card.Data);
            Grid.SetRow(cd, 1);
            Grid.SetRowSpan(cd, 2);
            grid.Children.Add(cd);

            if (ThemeManager.DarkSwitchOn)
            {
                HomeBtn.Source = @"Images\dark_home_btn_inactive.svg";
                GraphBtn.Source = @"Images\dark_graph_btn.svg";
            }
            else
            {
                HomeBtn.Source = @"Images\home_btn_inactive.svg";
                GraphBtn.Source = @"Images\graph_btn.svg";
            }

        }
        private void GraphBtn_Tapped(object sender, EventArgs e)
        {
            CardList.IsVisible = false;
            CardDetail cd = new CardDetail(App.Globals.LastViewedGraph, App.Globals.LastViewedData);
            Grid.SetRow(cd, 1);
            Grid.SetRowSpan(cd, 2);
            grid.Children.Add(cd);

            if (ThemeManager.DarkSwitchOn)
            {
                HomeBtn.Source = @"Images\dark_home_btn_inactive.svg";
                GraphBtn.Source = @"Images\dark_graph_btn.svg";
            }
            else
            {
                HomeBtn.Source = @"Images\home_btn_inactive.svg";
                GraphBtn.Source = @"Images\graph_btn.svg";
            }
        }
        private void HomehBtn_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DashBoardPage());
            ThemeManager.LoadTheme();
        }
        private void SideMenuBtn_Tapped(object sender, EventArgs e)
        {
            sideMenuView.sideMenuView.InputTransparent = false;
            sideMenuView.SideMenuBtn_Tapped(sender, e);
        }
    }
}