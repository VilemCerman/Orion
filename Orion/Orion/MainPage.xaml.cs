using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Orion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        public void LoginBtn_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Navigation.PushModalAsync(new DashBoardPage());            
        }
    }
}
