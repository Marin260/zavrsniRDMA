using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zavrsniRDMA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllUsers : ContentPage
    {
        List<AllUsersModel> modelList = new List<AllUsersModel>();

        public AllUsers()
        {
            InitializeComponent();

            GetJsonAsync();
        }

        public async Task GetJsonAsync()
        {
            var uri = new Uri("https://www.idt.mdh.se/personal/plt01/languide/?get=users");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string json = content.ToString();

                
                var jsonObject = JObject.Parse(json);
                var status = jsonObject["error"];
                var msg = jsonObject["msg"];
                var data = jsonObject["data"];

                var jsonArray = JArray.Parse(data.ToString());

                foreach(var userObject in jsonArray)
                {
                    AllUsersModel tmp = new AllUsersModel();

                    tmp.id_user = userObject["id_user"].ToString();
                    tmp.email = userObject["email"].ToString();
                    tmp.create_time = userObject["create_time"].ToString();

                    modelList.Add(tmp);
                }
            }

            allUsers.ItemsSource = modelList;
        }

        private void DeleteRequestedUsers(object sender, EventArgs e)
        {
            modelList.Clear();
            allUsers.ItemsSource = modelList;
        }
    }
}