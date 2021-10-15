using System;
using Domain;
using DomainServices;
using Infrastructure;
using MarketData;
using NetMQ;
using NetMQ.Sockets;
using VolTargetDAO;
using VolTargetRepository;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var responseSocket = new ResponseSocket("@tcp://*:5555"))
            {
                // To do : use serviceRegistration
                while (true)
                {
                    Console.WriteLine("Waiting for VolTarget to price...");
                    var message = responseSocket.ReceiveFrameString();
                    Console.WriteLine($"volTarget to price received : {message}\n");
                    var volTargetSerializer = new Serializer<VolTarget>();
                    VolTarget volTarget = volTargetSerializer.Deserialize(message);
                    var volTargetDAO = new VolTargetServicesDAO();
                    var volTargetRepo = new VolTargetPricingRepository(volTargetDAO);
                    var dataManagingService = new DataManagingService(volTargetRepo);
                    dataManagingService.InsertVolTarget(volTarget);

                    // TO DO : Price the vol target
                    Console.WriteLine("Vol Target price is : 100");
                    responseSocket.SendFrame("100");
                }
            }

            var yahooMarketData = new YahooMarketData();
            var listClosePrices = yahooMarketData.GetUnderlyingClosePriceAsync("AAPL", DateTime.Today.AddDays(-10), DateTime.Today);
            foreach( decimal d in listClosePrices.Result)
            {
                Console.WriteLine(d);
            }

        }
    }
}
