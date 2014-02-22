using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrummable
{
    class Bug
    {
        public Bug()
        {

        }
        public String Id { get; set; }
        public String Title { get; set; }
        public String AssignedTo { get; set; }
        public String FixBy { get; set; }
        public String NodeName { get; set; }
        public int Estimate { get; set; }
        public bool dirty = false;


    }
}
