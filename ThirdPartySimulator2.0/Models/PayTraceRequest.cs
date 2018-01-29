using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThirdPartySimulator2._0.Models
{
    public class PayTraceRequest //eft request
    {
        public double amount { get; set; }

        public string number { get; set; }

        public string holder { get; set; }//Added account holder.

    }
}