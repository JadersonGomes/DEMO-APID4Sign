using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOAPID4sign.Model
{
    public class Message
    {
        public string message { get; set; }
        public bool completed { get; set; }
        public string statusDescription { get; set; }
    }
}
