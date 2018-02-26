using SelfHostingServicePaymentLibraray;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace CarPoolingPaymentClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreditCardServiceReference.CreditCardServiceClient cc = new CreditCardServiceReference.CreditCardServiceClient();
            PaymentClient pc = new PaymentClient();
            Console.WriteLine("Enter credit card no.");
            string cno = Console.ReadLine();
            Console.WriteLine("Enter credit card Expiry date");
            DateTime expd = Convert.ToDateTime(Console.ReadLine());
            SelfHostingServicePaymentLibraray.CreditCard cc = new SelfHostingServicePaymentLibraray.CreditCard();
            cc.CCNo = cno; cc.ExpDate = expd;
            bool result=false;
            try
            {
                result = pc.ValidateCard(cc);
            }
            catch (FaultException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (ProtocolException ex)
            {

                Console.WriteLine(ex.Message);
            }
            if (result)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Invalid");
            DataContractSerializer dcs = new DataContractSerializer(typeof(CreditCard));
            using (Stream stream = new FileStream(@"D:\Tesco batch5\WCF\CarPoolingPaymentClient\file.xml",FileMode.Create,FileAccess.Write))
            {
                using(XmlDictionaryWriter writer=XmlDictionaryWriter.CreateTextWriter(stream,Encoding.UTF8))
                {
                    writer.WriteStartDocument();
                    dcs.WriteObject(writer, cc);
                }
            }



            Console.ReadLine();
        }
    }
}
