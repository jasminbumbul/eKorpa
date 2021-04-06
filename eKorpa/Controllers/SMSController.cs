using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Configuration;

namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class SmsController:TwilioController
    {
        private IConfiguration _iConfig;
        public SmsController(IConfiguration iConfig)
        {
            _iConfig = iConfig;
        }
        //public TwiMLResult Index(SmsRequest incomingMessage)
        //{
        //    var messagingResponse = new MessagingResponse();
        //    messagingResponse.Message("The copy cat says: " +
        //                              incomingMessage.Body);

        //    return TwiML(messagingResponse);
        //}

        public ActionResult SendSMS()
        {
            var accountSid = _iConfig.GetSection("Twilio").GetSection("AccountSid").Value;
            var authToken = _iConfig.GetSection("Twilio").GetSection("AuthToken").Value;

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(_iConfig.GetSection("Twilio").GetSection("MyPhoneNumber").Value);
            var from = new PhoneNumber("14243040193");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Test"
                );

            return Content(message.Sid);
        }
    }
}
