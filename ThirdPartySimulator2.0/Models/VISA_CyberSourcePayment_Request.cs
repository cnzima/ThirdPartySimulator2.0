using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThirdPartySimulator2._0.Models
{
    public class VISA_CyberSourcePayment_Request
    {
        public double amount { get; set; }

        public string currency { get; set; }

        public string cardNumber { get; set; }

        public string cardExpirationMonth { get; set; }

        public string cardExpirationYear { get; set; }

        public string CVV { get; set; }
    }
}