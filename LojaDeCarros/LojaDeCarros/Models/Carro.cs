using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaDeCarros.Models
{
    public class Carro
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string ano { get; set; }
    }
}