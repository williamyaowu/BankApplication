using Api.App.Bank.Services.Interface;
using Api.App.Bank.Models;
using Api.App.Bank.Persistance.Repositories;
using Api.App.Common.Services.Interface;
using Api.App.Bank.Persistance.Entities;

namespace Api.App.Bank.Services.Impl
{
    public class PaymentService
        : IPaymentService
    {
        private IPaymentRepository _paymentRepository;
        private IConverterManager _converterManager;

        public PaymentService(IPaymentRepository paymentRepo,
                              IConverterManager converterManager)
        {
            _paymentRepository = paymentRepo;
            _converterManager = converterManager;
        }

        public bool Save(PaymentModel paymentModel)
        {
            var paymentEntity = this._converterManager.Convert<PaymentModel, Payment>(paymentModel);

            _paymentRepository.Save(paymentEntity);

            return true;
        }
    }
}