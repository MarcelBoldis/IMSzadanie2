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
	public partial class Schedule : ContentPage
	{
		public Schedule ()
		{
			InitializeComponent ();
            TableData();
        }

        public void TableData()
        {
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load("http://www.automobilova-mechatronika.fei.stuba.sk/webstranka/?q=node/97/");
            var tables = doc.DocumentNode.SelectNodes("//div[contains(@class, 'table-responsive')]/table");

            string[] titles = new string[] { "1. Ročník Zimný Semester", "1. Ročník Letný Semester", "2. Ročník Zimný Semester", "2. Ročník Letný Semester" };

            var tablesec = 0;
            var firstRow = true;
            foreach (var table in tables)
            {
                TableSection ts = new TableSection(titles[tablesec++]);
                firstRow = true;

                foreach (var tbody in table.SelectNodes("tbody|thead"))
                {
                    foreach (var row in tbody.SelectNodes("tr"))
                    {
                        ViewCell vc = new ViewCell();
                        StackLayout sl = new StackLayout();
                        sl.Orientation = StackOrientation.Horizontal;

                        if (firstRow)
                        {
                            sl.BackgroundColor = Color.FromHex("#A83738");
                            firstRow = false;
                        }
                        else sl.BackgroundColor = Color.FromHex("#2B5F8C");
                        foreach (var cell in row.SelectNodes("th|td"))
                        {
                            Label l = new Label { Text = cell.InnerText, FontSize = 12 };
                            l.WidthRequest = 90;
                            l.TextColor = Color.White;
                            sl.Children.Add(l);
                        }
                        vc.View = sl;
                        ts.Add(vc);
                    }
                }
                tableRoot.Add(ts);
            }
        }
    }
}