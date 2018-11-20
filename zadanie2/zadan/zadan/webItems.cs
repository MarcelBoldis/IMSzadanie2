using System;
using System.Collections.Generic;
using System.Text;

namespace zadan
{
    public class webItems
    {
        public string href { get; set; }
        public string name { get; set; }

        public webItems(string href, string name)
        {
            this.href = href;
            this.name = name;
        }
    }
}
