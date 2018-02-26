using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILayer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            }
            catch (BusinessLayer.ProductDuplicateIDException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                    
                Console.WriteLine(ex.Message);
            }
        }
    }
}
