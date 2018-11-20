using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace zadan
{
    public partial class MainPage : MasterDetailPage
    {
        List<webItems> obj;
        public MainPage()
        {
            InitializeComponent();
            obj = htmlParser();
            picker.TextColor = Color.PaleVioletRed;
            IsPresented = false;
        }

        void Handle_Clicked1(Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new terminy())
            {
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.White
            };
            IsPresented = false;
        }

        void Handle_Clicked2(Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new novinky())
            {
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.White
            };
            IsPresented = false;
        }
        void Handle_Home(Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.White
            };
            IsPresented = false;
        }
        void Handle_Clicked3(Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new Schedule())
            {
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.White
            };
            IsPresented = false;
        }

        public List<webItems> htmlParser()
        {
            string url = "http://www.automobilova-mechatronika.fei.stuba.sk/webstranka/?q=node/59/";
            var Webget = new HtmlWeb();
            var doc = Webget.Load(url);
            var UlList = doc.DocumentNode.SelectNodes("//ul[contains(@class, 'list-4')]//li//a");
            List<webItems> ObjArray = new List<webItems>();
            foreach (var node in UlList)
            {
                string attr = node.Attributes["href"].Value;

                //osetrenie ak by sa v atribute href nenachadzala ziadna hodnota
                if (attr.Length > 1)
                {
                    webItems item = new webItems(attr, node.InnerHtml);
                    ObjArray.Add(item);
                    picker.Items.Add(item.name);
                }
            }
            return ObjArray;
        }


        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                string href = obj[selectedIndex].href;
                Detail = new NavigationPage(new Page1(href, obj, selectedIndex))
                {
                    BarBackgroundColor = Color.Black,
                    BarTextColor = Color.White
                };
                IsPresented = false;
            }
        }
        

    }
}
