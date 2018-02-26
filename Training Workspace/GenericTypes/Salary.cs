using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    public struct Salary
    {
        public double Basic;
        public short TA, DA, HRA;

        public Salary(double bas,short ta,short da,short hra)
        {
            Basic = bas;
            TA = ta;
            DA = da;
            HRA = hra;


        }
        public double GetTakeHomeSalary()
        {
            return Basic + Basic * (Convert.ToDouble(TA) / 100);
        }
    }
}
