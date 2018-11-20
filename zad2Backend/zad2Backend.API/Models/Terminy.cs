using System;

namespace zad2Backend.API.Models
{
    public class Terminy
    {
        public int id { get; set; }
        public string nazov { get; set; }
        public DateTime datum { get; set; }
        public string text { get; set; }
    }
}