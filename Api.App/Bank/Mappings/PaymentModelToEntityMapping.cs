using Api.App.Bank.Models;
using Api.App.Bank.Persistance.Entities;
using Api.App.Common.Services.Interface;

namespace Api.App.Common.Services.Impl
{
    public class PaymentModelToEntityMapping
        : AbstractMapping<PaymentModel, Payment>
    {
        public string Key
        {
            get
            {
                return string.Format(@"{0}:{1}", typeof(PaymentModel), typeof(Payment).FullName);
            }
        }

        public override object Convert(object obj)
        {
            var paymentModel = (PaymentModel)obj;

            return new Payment
            {
                BSB = paymentModel.BSB,
                AccountName = paymentModel.AccountName,
                AccountNumber = paymentModel.AccountNumber,
                Reference = paymentModel.Reference,
                PaymentAmount = paymentModel.PaymentAmount
            };
        }
    }
}