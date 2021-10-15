using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using VolTargetRepository;

namespace DomainServices
{
    public interface IDataManagingService
    {
        void InsertVolTarget(VolTarget volTarget);
    }
    public class DataManagingService
    {
        private readonly IVolTargetPricingRepository volTargetRepo;

        public DataManagingService(IVolTargetPricingRepository volTargetRepo)
        {
            this.volTargetRepo = volTargetRepo;
        }
        public void InsertVolTarget(VolTarget volTarget)
        {
            volTargetRepo.InsertVolTargetToDataBase(volTarget);
        }
    }
}
