using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public interface IRootFinder
    {
        int GetNumberOfRoots();
        List<string> GetRoots();

    }
}
