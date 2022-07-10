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
    public partial class SignUp : ContentPage
    {
        AuthRDMA auth;
        public SignUp()
        {
            InitializeComponent();
            auth = DependencyService.Get<AuthRDMA>();
        }

        private async void SignUpBtn_Clicked(object sender, EventArgs e)
        {
            var user = auth.SignUpWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);

            if (user != null)
            {
                await DisplayAlert("Success", "New User Created", "OK");

                var signOut = auth.SignOut();
                if (signOut)
                {
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                }
                
            }
            else
            {
                await DisplayAlert("ERROR", "Something went wrong", "OK");
            }
        }
    }
}