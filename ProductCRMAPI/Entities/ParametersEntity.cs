using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCRMAPI.Entities
{
    public class ParametersEntity
    {
        public string ProcAction { get; set; }
        public string Policyno { get; set; }
        public string Policyinfoid { get; set; }
        public string enumIsMasterPolicy { get; set; }
    }
}
