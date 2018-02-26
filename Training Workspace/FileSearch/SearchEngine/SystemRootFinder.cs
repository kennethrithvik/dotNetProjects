using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public class SystemRootFinder:AbstractRootFinder
    {

        public override List<string> GetRoots()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                roots.Add(drive.Name);   
            }
            return roots;
        }
    }
}
