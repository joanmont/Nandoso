using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Special.Models
{
    public class Specials
    {
        public int ID { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}