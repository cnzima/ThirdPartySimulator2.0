using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThirdPartySimulator2._0.Models
{
    public class VISA_CyberSourcePayment_Response
    {
        public long TransactionIdentifier { get; set; }
        public string ActionCode { get; set; }
        public string ApprovalCode { get; set; }
        public long ResponseSource { get; set; }
        public DateTime DateAndTimeTransmission { get; set; }
        public string FeeProgramIndicator { get; set; }
        public string Description { get; set; }
    }
}