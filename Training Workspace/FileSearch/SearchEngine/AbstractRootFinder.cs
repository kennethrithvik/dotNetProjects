using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public abstract class AbstractRootFinder:IRootFinder
    {
        public List<string> roots = new List<string>();
        public int GetNumberOfRoots()
        {
            return roots.Count;
        }

        public abstract List<string> GetRoots();
        
    }
}
