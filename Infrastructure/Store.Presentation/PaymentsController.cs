using Microsoft.AspNetCore.Mvc;
using Store.Domain.Contract;
using Store.Domain.Entities.Orders;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController(IServiceManager _serviceManager, IUnitOfWork _unitOfWork) : ControllerBase
    {
        //create payment intent
        [HttpPost("{basketId}")]
        public async Task<IActionResult> CreatePaymentIntent(string basketId)
        {
            var result = await _serviceManager.PaymentService.CreatePaymentIntentAsync(basketId);
            return Ok(result);
        }

        //To Do
        ////stripe listen --forward-to https://localhost:7148/api/Payments/webhook
        //[Route("webhook")]
        //[HttpPost]
        //public async Task<IActionResult> Index()
        //{
        //    var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        //    const string endpointSecret = "whsec_7c4755f0a83bbf4486b9ff733ccb545ae7b2a658f8a3b89415379ccbcd92d3e1";
        //    var stripeEvent = EventUtility.ParseEvent(json);
        //    var signatureHeader = Request.Headers["Stripe-Signature"];

        //    stripeEvent = EventUtility.ConstructEvent(json,
        //            signatureHeader, endpointSecret);

        //    // If on SDK version < 46, use class Events instead of EventTypes
        //    if (stripeEvent.Type == EventTypes.PaymentIntentSucceeded)
        //    {
        //        //Update Order Status to success
        //        var order =  await _unitOfWork.GetRepository<Guid, Order>().GetAsync()
        //        var order = _unitOfWork.GetRepository<Guid, Order>().Update()
        //    }

        //    else if (stripeEvent.Type == EventTypes.PaymentIntentPaymentFailed)
        //    {
        //        //Update Order Status to failed
        //    }

        //    else
        //    {
        //        Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
        //    }
        //    return Ok();

        //}
    }
}
