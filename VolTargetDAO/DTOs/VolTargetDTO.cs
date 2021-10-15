using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolTargetDAO.DTOs
{
    public class VolTargetDTO
    {
        public int IdVolTarget { get; set; }
        public double Volatility { get; set; }
        public DateTime StartDate { get; set; }
        public string Underlying { get; set; }
        public string VoltargetTrader { get; set; }
        public string VolTargetName { get; set; }

        public VolTargetDTO(double vol, DateTime date, string underl, string trader, string name)
        {
            Volatility = vol;
            StartDate = date;
            Underlying = underl;
            VoltargetTrader = trader;
            VolTargetName = name;
        }

        public VolTargetDTO()
        {
        }
    }
}
