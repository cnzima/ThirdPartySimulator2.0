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
            suceessMsg.avs_response = "Full Exact Match";
            suceessMsg.csc_response = "Match";
            suceessMsg.external_transaction_id = "";
            if(request != null) { suceessMsg.masked_card_number = "xxxxxxxxxxxx" + request.number.Substring(request.number.Length - 4); }

            failMsg.transaction_id = tranID;
            failMsg.success = false;
            failMsg.status_message = "Your transaction was not approved.";
            failMsg.response_code = 102;
            failMsg.approval_code = "";
            failMsg.approval_message = "DECLINE - Do not honor";
            failMsg.avs_response = "Full Exact Match";
            failMsg.csc_response = "Match";
            failMsg.external_transaction_id = "";
            if (request != null) { failMsg.masked_card_number = "xxxxxxxxxxxx" + request.number.Substring(request.number.Length - 4); }


            bool delayResponse = (rnd.Next(2) == 1) ? true : false;

            if (delayResponse)
            {
                int delayTime = rnd.Next(500, 3000);
                System.Threading.Thread.Sleep(delayTime);
            }

            bool successful = true;

            if (request != null)
            {
                Match match = Regex.Match(request.number, "^[0-9]{16}$");

                if (!match.Success)
                {
                    successful = false;

                }

                match = Regex.Match(request.expiration_month, "^[0-9]{2}$");

                if (!match.Success)
                {
                    successful = false;

                }

                match = Regex.Match(request.expiration_year, "^[0-9]{4}$");

                if (!match.Success)
                {
                    successful = false;

                }

                string expiryDate = "01/" + request.expiration_month + "/" + request.expiration_year;
                DateTime cardExpiryDate = Convert.ToDateTime(expiryDate);

                if (cardExpiryDate < DateTime.Now)
                {
                    successful = false;

                }

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
