using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Trader
    {
        public string trader { get; set; }

        public Trader()
        { }

        public Trader(string nom)
        {
            trader = nom;
        }
    }
}
