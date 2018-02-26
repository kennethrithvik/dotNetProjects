using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSearch
{
    public class Searcher
    {
        private List<string> matches = new List<string>(); 
        public List<string> search(string fname)
        {
            DriveInfo[] AllDrives = DriveInfo.GetDrives();
            foreach (var drive in AllDrives)
            {
                if (drive.IsReady&&(drive.Name.Contains("D:")))
                {
                    string[] files1 = Directory.GetFiles(@"D:\HappyTrip", "*" + fname + "*", SearchOption.AllDirectories);
                    foreach (var file in files1)
                    {
                        matches.Add(file);
                    }

                }
            }
            return matches;
        }


        public string display(List<string> matches)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var file in matches)
            {
                sb.Append(file + "\n");
            }
            sb.Append(matches.Count + " Files found");
            return sb.ToString();
        }

    }


}
