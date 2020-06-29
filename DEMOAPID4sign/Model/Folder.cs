using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOAPID4sign.Model
{
    public class Folder
    {
        public string uuid_safe { get; set; }
        public string uuid_folder { get; set; }
        public string name { get; set; }
        public DateTime dt_cadastro { get; set; }
        public string statusDescription { get; set; }
    }
}
