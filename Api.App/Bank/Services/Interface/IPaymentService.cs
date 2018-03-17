using Api.App.Bank.Models;

namespace Api.App.Bank.Services.Interface
{
    public interface IPaymentService
    {
        bool Save(PaymentModel payment);
    }
}
