using Api.App.Bank.Models;
using Api.App.Bank.Persistance.Entities;
using Api.App.Bank.Persistance.Repositories;
using Api.App.Bank.Services.Impl;
using Api.App.Common.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Api.AppTests
{
    [TestClass]
    public class PaymentServiceTests
    {
        private PaymentService _paymentService;

        private Mock<IPaymentRepository> _paymentRepositoryMock;
        private Mock<IConverterManager> _converterManageMock;

        [TestInitialize]
        public void Initial()
        {
            _paymentRepositoryMock = new Mock<IPaymentRepository>();
            _converterManageMock = new Mock<IConverterManager>();

            _paymentService = new PaymentService(_paymentRepositoryMock.Object, _converterManageMock.Object);
        }

        [TestMethod]
        public void Payment_WillBeConvertAndSave()
        {
            var paymentModel = new PaymentModel { BSB = "123", AccountNumber = "456", AccountName = "testAccount", Reference = "ref", PaymentAmount = 100 };
            var payment= new Payment { BSB = "123", AccountNumber = "456", AccountName = "testAccount", Reference = "ref", PaymentAmount = 100 };

            _converterManageMock.Setup(p => p.Convert<PaymentModel, Payment>(It.IsAny<PaymentModel>())).Returns(payment);
            _paymentRepositoryMock.Setup(p => p.Save(It.IsAny<Payment>()));

            _paymentService.Save(paymentModel);

            _converterManageMock.Verify(p => p.Convert<PaymentModel, Payment>(It.IsAny<PaymentModel>()), Times.Exactly(1));
            _paymentRepositoryMock.Verify(p => p.Save(It.IsAny<Payment>()),Times.Exactly(1));

        }


    }
}
