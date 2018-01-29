using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThirdPartySimulator2._0.Models
{
    public class PayTraceRequest//eft request
    {
        public double amount { get; set; }

        public string currency { get; set; }//

        public string number { get; set; }

        public string holder { get; set; }//Added account holder.

        public string expiration_month { get; set; }//Dont think there is any Experation details in a account number

        public string expiration_year { get; set; }

        public string csc { get; set; }//
    }
}