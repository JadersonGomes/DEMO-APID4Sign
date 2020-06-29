using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOAPID4sign.Model
{
    public class Document
    {
        public string uuidDoc { get; set; }
        public string nameDoc { get; set; }
        public string type { get; set; }
        public string size { get; set; }
        public string pages { get; set; }
        public string uuidSafe { get; set; }
        public string safeName { get; set; }
        public string statusId { get; set; }
        public string statusName { get; set; }
        public string statusDescription { get; set; }
    }
}
