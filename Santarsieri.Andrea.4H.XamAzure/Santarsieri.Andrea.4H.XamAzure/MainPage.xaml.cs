using Newtonsoft.Json;
using Santarsieri.Andrea._4H.XamAzure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Santarsieri.Andrea._4H.XamAzure
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            List<Studente> elenco = new List<Studente>();

            try
            {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync("https://flr.azurewebsites.net/studenti");
                elenco = JsonConvert.DeserializeObject<List<Studente>>(response);
            }
            catch (Exception err)
            {
                await DisplayAlert("Ocio!!", err.Message, "Ok");
            }
            //elenco.Add(new Studente { Nome="Andrea" , Cognome="Santarsieri" });
            //elenco.Add(new Studente { Nome = "Fabio", Cognome = "Corbelli" });
            //elenco.Add(new Studente { Nome = "Maurizio", Cognome = "Conti" });

            lvStudenti.ItemsSource = elenco;
        }
    }

}
