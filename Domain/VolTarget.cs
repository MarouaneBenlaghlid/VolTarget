using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class VolTarget
    {
        public double Volatility;
        public DateTime StartDate;
        public Trader VolTargetTrader;
        public List<Underlying> Underlyings;
        public string VolTargetName;
    }
}
