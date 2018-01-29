using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThirdPartySimulator2._0.Models
{
    public class PayTraceResponse
    { 
        public bool success { get; set; }

        public int response_code { get; set; }
        public string status_message { get; set; }
        public long transaction_id { get; set; }
        public string approval_code { get; set; }
        //CN 29-01-2018 Removed fields irrevant to EFT
        public string external_transaction_id { get; set; }
        public string approval_message { get; internal set; }
    }
}