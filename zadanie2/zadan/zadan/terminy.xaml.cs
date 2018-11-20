using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zadan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class terminy : ContentPage
    {
        public terminy()
        {
            InitializeComponent();
            getRESTResponse();
        }


        public async void getRESTResponse()
        {
            try
            {
                var RestUrl = "https://ims-zadanie2-xboldis.azurewebsites.net/api/terminy";
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(RestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<Terminy>>(content);
                    List<Terminy> termins = JsonConvert.DeserializeObject<List<Terminy>>(content);
                    termins.ForEach(item =>
                    {
                        addTermin(item.nazov, item.datum, item.text);
                    });
                }
            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
            }
        }

        public void addTermin(string nazov, string datum, string popis)
        {
            string[] strArray = datum.Split('T');
            string[] dateArray = strArray[0].Split('-');
            datum = "\n Čas: " + dateArray[2] + "." + dateArray[1] + "." + dateArray[0];

            Frame f = new Frame ()
            {
                BorderColor = Color.FromHex("#1A1A24"),
                BackgroundColor = Color.FromHex("#046263"),
                Margin = 8,
                Content = new Label()
                {
                    Text = nazov + datum,
                    Margin = new Thickness(5, 5, 5, 0),
                    TextColor = Color.White,
                    FontSize = 15,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontFamily = "{StaticResource NormalFont}",
                },
            };
            f.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked(nazov, datum, popis)));
            layout.Children.Add(f);
        }
        public void OnLabelClicked(string nazov, string datum, string popis)
        {
            DisplayAlert(nazov + datum, popis, "OK");
        }
    }
}