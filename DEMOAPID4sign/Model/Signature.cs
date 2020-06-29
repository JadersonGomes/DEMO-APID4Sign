using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOAPID4sign.Model
{
    public class Signature
    {
        
        public string key_signer { get; set; }
        public string email { get; set; }
        public string act { get; set; }
        public string foreign { get; set; }
        public string certificadoicpbr { get; set; }
        public string assinatura_presencial { get; set; }
        public string doc_auth { get; set; }
        public string embed_methodauth { get; set; }
        public string embed_smsnumber { get; set; }
        public string upload_allow { get; set; }
        public string upload_obs { get; set; }
        public string status { get; set; }
        public string statusDescription { get; set; }

    }

    public class SignatureList
    {
        public List<Signature> message { get; set; }
    }
}
