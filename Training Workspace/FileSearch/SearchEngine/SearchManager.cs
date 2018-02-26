using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SearchEngine
{
    public class SearchManager
    {
        FileSearcher searcher = new FileSearcher();
        public void StartSearch(string drivetosearch,string filetosearch)
        {
            searcher.Search(drivetosearch, filetosearch);
        }

        public List<string> GetSearchResutls()
        {
            return searcher.GetFileFoundResults();
        }
        public int GetNumberOfFOldersScanned()
        {
            return searcher.GetNumberOfFOldersScanned();
        }

    }
}
