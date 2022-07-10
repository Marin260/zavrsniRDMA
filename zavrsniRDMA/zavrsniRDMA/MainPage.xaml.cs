using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace zavrsniRDMA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }


        private async void NavigateToAllUsers(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllUsers());
        }
        private async void NavigateToResults(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Results());
        }
        private async void NavigateToLanguages(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Languages());
        }
    }
}
