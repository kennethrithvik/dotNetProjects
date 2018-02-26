using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOB
{
    public class IdGenerator
    {
        private static int idGen;

        static IdGenerator()
        {
            idGen = 1;
        }

        public static int generateId()
        {
            return idGen++;
        }
    }
}
