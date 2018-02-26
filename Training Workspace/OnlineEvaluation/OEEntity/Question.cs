using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEEntity
{
    public class Question
    {
        public Question()
        {
            
        }

        public byte qid { get; set; }
        public string question { get; set; }

        public byte marks { get; set; }

        public List<Option> options { get; set; }
        public List<Option> coptions { get; set; }


    }
}
