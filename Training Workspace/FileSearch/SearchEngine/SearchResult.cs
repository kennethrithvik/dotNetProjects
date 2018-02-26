using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public  class SearchResult
    {
        private List<string> SearchResultLog = new List<string>();
        
        public int NumberOfFoldersScanned { get; set; }

        public void AddSearchResult(string result)
        {
            SearchResultLog.Add(result);

        }
        
        public List<string> GetSearchResults()
        {
            return SearchResultLog;
        }
        public int GetNumberOfFOldersScanned()
        {
           
            return this.NumberOfFoldersScanned;
            
        }

    }
}
