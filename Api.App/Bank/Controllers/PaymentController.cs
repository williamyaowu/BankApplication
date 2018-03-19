using Api.App.Bank.Models;
using Api.App.Bank.Services.Interface;
using System.Web.Http;

namespace Api.App.Bank.Controllers
{
    public class PaymentController : ApiController
    {
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this._paymentService = paymentService;
        }

        [Route("Payment")]
        [HttpPost]
        public IHttpActionResult CreatePayment(PaymentModel payment)
        {

            this._paymentService.Save(payment);

            return this.Ok();
        }
    }
}
