using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTreeConstruction
{
    public class OrgModel
    {
        public int OrgId{get;set; }
        public string OrgName { get; set; }

        public int? ParentOrgId { get; set; }
    }
}
