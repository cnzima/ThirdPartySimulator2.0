using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using ThirdPartySimulator2._0.Models;

namespace ThirdPartySimulator2._0.Controllers
{

    public class PayTracePaymentController : ApiController
    {
        private const double VALUE_LIMIT = 500000.00;

        // GET: api/PayTracePayment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PayTracePayment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PayTracePayment
        public PayTraceResponse Post([FromBody]PayTraceRequest request)
        {
            PayTraceResponse suceessMsg = new PayTraceResponse();
            PayTraceResponse failMsg = new PayTraceResponse();

            Random rnd = new Random();

            long tranID = rnd.Next(10000, 99999);
            suceessMsg.transaction_id = tranID;
            suceessMsg.success = true;
            suceessMsg.status_message = "Your transaction was successfully approved.";
            suceessMsg.response_code = 101;
            suceessMsg.approval_code = "TAS677";
            suceessMsg.approval_message = "EXACT MATCH - Approved and completed";
            suceessMsg.external_transaction_id = "";

            failMsg.transaction_id = tranID;
            failMsg.success = false;
            failMsg.status_message = "Your transaction was not approved.";
            failMsg.response_code = 102;
            failMsg.approval_code = "";
            failMsg.approval_message = "DECLINE - Do not honor";
            failMsg.external_transaction_id = "";

            bool delayResponse = (rnd.Next(2) == 1) ? true : false;

            if (delayResponse)
            {
                int delayTime = rnd.Next(500, 3000);
                System.Threading.Thread.Sleep(delayTime);
            }

            bool successful = true;

            if (request != null)
            {
                #region Validate account numbers 
                Match match = Regex.Match(request.beneficiaryAcc, "^[0-9]{10}$");

                if (!match.Success)
                {
                    successful = false;
                    failMsg.status_message = "Invalid beneficiary account number";
                }

                match = Regex.Match(request.beneficiarySortCode, "^[0-9]{6}$");

                if (!match.Success)
                {
                    successful = false;
                    failMsg.status_message = "Invalid beneficiary sort code";
                }

                match = Regex.Match(request.remitterAcc, "^[0-9]{10}$");

                if (!match.Success)
                {
                    successful = false;
                    failMsg.status_message = "Invalid remitter account number";
                }

                match = Regex.Match(request.remitterSortCode, "^[0-9]{6}$");

                if (!match.Success)
                {
                    successful = false;
                    failMsg.status_message = "Invalid remitter sort code";
                }

                
                if (request.amount > VALUE_LIMIT)
                {
                    successful = false;
                    failMsg.status_message = "Amount exceeds the value limits";
                }
                #endregion Validate account numbers 

                return (successful) ? suceessMsg : failMsg;
            }else
            {
                failMsg.status_message = "Invalid Request was sent";
                return failMsg;
            }
        }


        // PUT: api/PayTracePayment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PayTracePayment/5
        public void Delete(int id)
        {
        }
    }
}
