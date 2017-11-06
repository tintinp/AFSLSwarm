using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmLibrary
{
    public class COMPort
    {
        public List<string> PortList { get; set; }

        public COMPort()
        {
            PortList = new List<string>();
        }
    }
}
