using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SearchEngine
{
    public class FileSearcher
    {
        /// <summary>
        /// Instance of SearchResult to Access the methods of that class
        /// </summary>
        static SearchResult result = new SearchResult();
        /// <summary>
        /// Performs Core Searching Operation
        /// </summary>
        /// <param name="drivetosearch"></param>
        /// <param name="filetosearch"></param>
        public void Search(string drivetosearch, string filetosearch)
        {
           
            String[] Directories = Directory.GetDirectories(drivetosearch);
            string[] files = Directory.GetFiles(drivetosearch);
            string absolutefile = string.Empty;
            foreach (var file in files)
            {
                absolutefile = drivetosearch + filetosearch;
                if (file == absolutefile)
                {
                    result.AddSearchResult(absolutefile);
                }
            }
            try
            {
                foreach (var dir in Directories)
                {
                    result.NumberOfFoldersScanned++;
                    Search(dir, filetosearch);
                }
            }
            catch (UnauthorizedAccessException ue) { }

        }

        public List<string> GetFileFoundResults()
        {
            return result.GetSearchResults();
        }
        public int GetNumberOfFOldersScanned()
        {
            return result.GetNumberOfFOldersScanned();
        }
    }
}
