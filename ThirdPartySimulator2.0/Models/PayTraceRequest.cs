using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThirdPartySimulator2._0.Models
{
    public class PayTraceRequest //eft request
    {
        public double amount { get; set; }

        public string remitterAcc { get; set; }

        public string remitterSortCode { get; set; }

        public string beneficiaryAcc { get; set; }

        public string beneficiarySortCode { get; set; }

        public string beneficiaryName { get; set; }

        public string remitterName { get; set; }//Added account holder.

        public string narration { get; set; }

    }
}