using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    class MathClass
    {
        public event EventHandler myevent ;
        private int mintNum1;

        public int Num1
        {
            get { return mintNum1; }
            set { mintNum1 = value; }
        }

        public int Num2;


        [Bug("Kenneth", "10/10/2015", "Concatinating Values", Corrected = "Kenneth", CorrectedDate = "11/10/2015")]
        public long Add()
        {
            return Num1 + Num2;
        }

       [Bug("Kenneth123", "10/10/2015", "Concatinating Values", Corrected = "Kenneth", CorrectedDate = "11/10/2015")]
        public static long Multiply(int n1,int n2,int n3)
        {
            return n1*n2*n3;
        }



        public MathClass()
        {
            
        }
        private void M1()
        {
            
        }
        protected void M2()
        {

        }
        internal void M3()
        {

        }
    }

    class MyException:ApplicationException
    {
        
    }
    interface IMyInterface
    {

    } 
}
