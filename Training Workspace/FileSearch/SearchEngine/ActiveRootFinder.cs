using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class ActiveRootFinder:AbstractRootFinder
    {

        public override List<string> GetRoots()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                if (drive.IsReady == true)
                {
                    roots.Add(drive.Name);
                }
                
            }
            return roots;
        }
    }
}
