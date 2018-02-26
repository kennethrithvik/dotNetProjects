using SelfHostingServicePaymentLibraray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServicePublishingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "net.tcp://localhost:9005/MyService/Payment/";
            ServiceHost host = null;
            try
            {
                Uri AddrBase = new Uri(address);
                host = new ServiceHost(typeof(Payment), AddrBase);
                NetTcpBinding ntb = new NetTcpBinding();

                ServiceMetadataBehavior mBehav = new ServiceMetadataBehavior();
                host.Description.Behaviors.Add(mBehav);
                host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

                host.AddServiceEndpoint(typeof(IPayment), ntb, address);
                host.Open();
                Console.WriteLine("\n\nService is running as >>"+address);

            }
            catch (Exception ex)
            {
                host = null;
                Console.WriteLine("Service cannot be started as ["+address+"]\nmsg= "+ex.Message);
            }



            Console.ReadLine();
        }
    }
}
