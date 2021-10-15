using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure
{
    public interface ITcpTransportManager
    {
        // TO DO : Add all usefull methods.
    }
    public class TcpTransportManager
    {
        private readonly string adress;
        private readonly ISerializer<VolTarget> volTargetSerializer;

        public TcpTransportManager(string endPoint, int port)
        {
            this.adress = $">tcp://{endPoint}:{port}";
            this.volTargetSerializer = new Serializer<VolTarget>();
        }

        // TO DO : Override all usefull methods
    }
}
