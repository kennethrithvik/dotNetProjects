using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerDemo.Models
{
    public class StateData
    {
        private IList<State> statelist;
        public StateData()
        {
            statelist=new List<State>();
        }
        public void AddState(State st)
        {
            statelist.Add(st);
        }
        public IList<State> GetList()
        {
            return statelist;
        }
    }
}