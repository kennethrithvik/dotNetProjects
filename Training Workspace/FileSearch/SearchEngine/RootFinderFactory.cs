using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class RootFinderFactory
    {
        //Creating Singleton
        private RootFinderFactory()
        {

        }
         static RootFinderFactory factory = new RootFinderFactory();

        public static RootFinderFactory GetInstance()
         {
             return factory;
         }
       
        public IRootFinder Create(Roots root)
        {
            IRootFinder finder = null;
            switch (root)
            {
                case Roots.ACTIVE: finder = new ActiveRootFinder();
                    break;
                case Roots.SYSTEM: finder = new SystemRootFinder();
                    break;
                default:
                    break;
            }
            return finder;
        }
    }
}
