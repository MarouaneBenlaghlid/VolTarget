using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Underlying
    {
        public string Name;
        public string Type;

        public Underlying() { }

        public Underlying(string Name)
        {
            this.Name = Name;
        }
    }
}
