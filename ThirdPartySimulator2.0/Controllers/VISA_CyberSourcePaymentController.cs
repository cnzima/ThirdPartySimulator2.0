using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using ThirdPartySimulator2._0.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ThirdPartySimulator2._0.Controllers
{
    public class VISA_CyberSourcePaymentController : ApiController
    {

        // GET: api/VISA_CyberSourcePayment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/VISA_CyberSourcePayment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/VISA_CyberSourcePayment
        public VISA_CyberSourcePayment_Response Post([FromBody]VISA_CyberSourcePayment_Request request)
        {
           
            JavaScriptSerializer jss = new JavaScriptSerializer();
            VISA_CyberSourcePayment_Response suceessMsg = new VISA_CyberSourcePayment_Response();
            VISA_CyberSourcePayment_Response failMsg = new VISA_CyberSourcePayment_Response();

            Random rnd = new Random();

            long tranID = rnd.Next(10000, 99999);
            suceessMsg.TransactionIdentifier = tranID;
            suceessMsg.ActionCode = "00";
            suceessMsg.ApprovalCode = "1";
            suceessMsg.ResponseSource = tranID;
            suceessMsg.DateAndTimeTransmission = DateTime.Now;
            suceessMsg.FeeProgramIndicator = "123";
            suceessMsg.Description = "Payment Successful";

            failMsg.TransactionIdentifier = tranID;
            failMsg.ActionCode = "00";
            failMsg.ApprovalCode = "0";
            failMsg.ResponseSource = tranID;
            failMsg.DateAndTimeTransmission = DateTime.Now;
            failMsg.FeeProgramIndicator = "123";

            bool delayResponse = (rnd.Next(2) == 1) ? true : false;

            if (delayResponse)
            {
                int delayTime = rnd.Next(500, 3000);
                System.Threading.Thread.Sleep(delayTime);
            }

            bool successful = true;

            if (request != null)
            {
                Match match = Regex.Match(request.cardNumber, "^[0-9]{16}$");

                if (!match.Success)
                {
                    successful = false;
                    failMsg.Description = "Invalid Card Number";
                }

                match = Regex.Match(request.cardExpirationMonth, "^[0-9]{2}$");

                if (!match.Success)
                {
                    successful = false;
                    failMsg.Description = "Invalid Card Expiration Month";
                }

                match = Regex.Match(request.cardExpirationYear, "^[0-9]{4}$");//

                if (!match.Success)
                {
                    successful = false;
                    failMsg.Description = "Invalid Card Expiration Year";
                }

                string expiryDate = "01/" + request.cardExpirationMonth + "/" + request.cardExpirationYear;
                DateTime cardExpiryDate = Convert.ToDateTime(expiryDate);

                if (cardExpiryDate < DateTime.Now)
                {
                    successful = false;
                    failMsg.Description = " Card has expired";
                }

                return (successful) ? suceessMsg : failMsg;
            }else
            {
                failMsg.Description = "Invalid request was sent";
                return  failMsg;
            }
        }

        // PUT: api/VISA_CyberSourcePayment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VISA_CyberSourcePayment/5
        public void Delete(int id)
        {
        }
    }
}
