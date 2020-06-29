using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOAPID4sign.Model
{
    public class InfoSignature
    {
        public string key_signer { get; set; }
        public string user_name { get; set; }
        public string user_document { get; set; }
        public string email { get; set; }
        public string signed { get; set; }
        public string type { get; set; }
        public string foreign { get; set; }
        public string certificadoicpbr { get; set; }
        public string assinatura_presencial { get; set; }
        public string embed_methodauth { get; set; }
        public string embed_smsnumber { get; set; }
        public string email_sent { get; set; }
        public string email_sent_status { get; set; }
        public string email_sent_message { get; set; }
        public string date { get; set; }        
        public string upload_allowed { get; set; }
        public string docauth { get; set; }
        public string docauthandselfie { get; set; }
        public string statusDescription { get; set; }
    }

    public class InfoSignatureList
    {
        public List<InfoSignature> list { get; set; }
    }
}
