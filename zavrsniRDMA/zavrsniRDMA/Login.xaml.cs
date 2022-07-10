using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zavrsniRDMA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        AuthRDMA auth;

        public Login()
        {
            InitializeComponent();
            auth = DependencyService.Get<AuthRDMA>();
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            string token = await auth.LoginWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);
            if (token != string.Empty)
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                await DisplayAlert("ERROR", "Auth Failed", "OK");
            }
        }

        private async void SignUpBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }
    }
}