using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using VolTargetDAO;
using VolTargetDAO.DTOs;

namespace VolTargetRepository
{
    public interface IVolTargetPricingRepository
    {
        void InsertVolTargetToDataBase(VolTarget volTarget);
        List<VolTarget> GetVolTargetByName(string name);
    }
    public class VolTargetPricingRepository : IVolTargetPricingRepository
    {
        private readonly IVolTargetServicesDAO volTargetServiceDAO;
        public VolTargetPricingRepository(IVolTargetServicesDAO volTargetServiceDAO)
        {
            this.volTargetServiceDAO = volTargetServiceDAO;
        }
        public void InsertVolTargetToDataBase(VolTarget volTarget)
        {
            foreach (Underlying underlying in volTarget.Underlyings)
            {
                var volTargetDTO = new VolTargetDTO(volTarget.Volatility, volTarget.StartDate, volTarget.VolTargetTrader.trader, underlying.Name, volTarget.VolTargetName);
                this.volTargetServiceDAO.InsertVolTarget(volTargetDTO);
            }
        }

        public List<VolTarget> GetVolTargetByName(string name)
        {
            var result = new List<VolTarget>();
            var volTargetDTOs = this.volTargetServiceDAO.GetVolTargetDTOs(name);
            foreach(var volTargetDTO in volTargetDTOs)
            {
                var volTarget = new VolTarget();
                volTarget.Volatility = volTargetDTO.Volatility;
                volTarget.StartDate = volTargetDTO.StartDate;
                volTarget.VolTargetTrader = new Trader(volTargetDTO.VoltargetTrader);
            }
            return result;
        }
    }
}
