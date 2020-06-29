using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOAPID4sign.Model
{
    public class Clausula
    {
        public int success { get; set; }
        public string email { get; set; }
        public string key_signer { get; set; }
        public string text { get; set; }
        public string statusDescription { get; set; }
    }
}
