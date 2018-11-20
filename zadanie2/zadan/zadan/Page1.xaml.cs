using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zadan
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        public string href = "";
        List<webItems> obj;
        public int selectedIndex;
        public Page1 (string odkaz, List<webItems> obj, int selectedIndex)
		{
			InitializeComponent ();
            this.href = odkaz;
            this.obj = obj;
            this.selectedIndex = selectedIndex;
            BindingContext = this;
            getInfoFromPage(href);
        }

        public string WordCount
        {
            get { return obj[selectedIndex].name; }
        }

        public void getInfoFromPage(string href)
        {

            string url = "http://www.automobilova-mechatronika.fei.stuba.sk/webstranka/" + href;
            var Webget = new HtmlWeb();
            var doc = Webget.Load(url);
            var UlList1 = doc.DocumentNode.SelectNodes("//div[contains(@class, 'content-block')]");
            var UlList2 = doc.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-6')]");
            
            foreach (var node in UlList1)
            {
                if (node.ChildNodes[1].OriginalName == "h3")
                {
                    createHeadingH3(node.ChildNodes[1].InnerText);
                }
                if (node.ChildNodes[3].OriginalName == "span")
                {
                    createParagraph(node.ChildNodes[3].InnerText);
                }
            }

            foreach (var node in UlList2)
            {
                if (node.ChildNodes[1].OriginalName == "img")
                {
                    createImage(node.ChildNodes[1].Attributes["src"].Value);
                }

                if (node.ChildNodes[1].OriginalName == "h3")
                {
                    createHeadingH3(node.ChildNodes[1].InnerText);
                    foreach (var para in node.ChildNodes)
                    {
                        if (para.OriginalName == "p")
                        {
                            createParagraph(para.InnerText);
                        }
                    }
                }
            }
        }
        
        public void createHeadingH3(string text)
        {
            Label label = new Label
            {
                Text = text,
                Margin = new Thickness(15, 10),
                TextColor = Color.FromHex("#50A5A6"),
                FontSize = 28,
                FontFamily = "{StaticResource NormalFont}",
                FontAttributes = FontAttributes.Bold,
            };
            layout.Children.Add(label);
        }

        public void createParagraph (string text)
        {
            Label p = new Label
            {
                Text = text,
                Margin = new Thickness(15, 5, 10, 0),
                TextColor = Color.White,
                FontSize = 20,
                FontFamily = "{StaticResource NormalFont}",
            };

            layout.Children.Add(p);
        }
        public void createImage(string value)
        {
            string source = value;
            string myString = source.Replace("/webstranka/", "");
            string odkaz = "http://www.automobilova-mechatronika.fei.stuba.sk/webstranka/" + myString;
            Image image = new Image
            {
                Source = odkaz,
                Margin = 10,
            };
            layout.Children.Add(image);
        }
    }
}