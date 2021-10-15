using System;
using System.Collections.Generic;
using System.Threading;
using Domain;
using Infrastructure;
using NetMQ;
using NetMQ.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var requestSocket = new RequestSocket(">tcp://localhost:5555"))
            {
                while (true)
                {
                    var volTarget = new VolTarget();

                    // Get user's vol target to price
                    Console.WriteLine("Please enter the voltarget's name:...");
                    volTarget.VolTargetName = Console.ReadLine();

                    Console.WriteLine("Please enter the volatility:...");
                    volTarget.Volatility = double.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the Start date:...");
                    volTarget.StartDate = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the trader:...");
                    volTarget.VolTargetTrader = new Trader(Console.ReadLine());

                    List<Underlying> list_underlyings = new List<Underlying>();
                    Console.WriteLine("Please enter the first underlying:...");
                    var condition = true;
                    while (condition)
                    {
                        list_underlyings.Add(new Underlying(Console.ReadLine()));
                        Console.WriteLine("Do you want to add another underlying? (1/0)");
                        string continueString = Console.ReadLine();
                        if(continueString == "0")
                        {
                            condition = false;
                            Console.WriteLine("Waiting for server to price...");
                            // To do : send volTarget to be priced...
                        }
                        else
                        {
                            Console.WriteLine("Please enter the underlying...");
                        }
                    }
                    volTarget.Underlyings = list_underlyings;
                    // Serialize volTarget
                    var volTargetSerializer = new Serializer<VolTarget>();
                    string serializedVolTarget = volTargetSerializer.Serialize(volTarget);

                    //Send the serialized volTarget
                    requestSocket.SendFrame(serializedVolTarget);
                    var message = requestSocket.ReceiveFrameString();
                    Console.WriteLine("Socket received volTarget");
                    Thread.Sleep(5000);
                }
            }
        }
    }
}