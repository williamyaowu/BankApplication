using Api.App.Bank.Persistance.Entities;
using Api.App.Bank.Persistance.Repositories;
using Api.App.Infrastructure.Persistance.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Api.AppTests
{
    [TestClass]
    public class PaymentRepositoryTest
    {
        private PaymentRepository _paymentRepository;

        private Mock<IPersistancSession> _persistancSessionMock;

        [TestInitialize]
        public void Initialize()
        {
            _persistancSessionMock = new Mock<IPersistancSession>();

            _paymentRepository = new PaymentRepository(_persistancSessionMock.Object);
        }

        [TestMethod]
        public void Payment_SaveGoToPersistance()
        {
            _persistancSessionMock.Setup(p => p.Write(It.IsAny<Payment>()));
            var payment = new Payment();
            _paymentRepository.Save(payment);

            _persistancSessionMock.Verify(p => p.Write(It.IsAny<Payment>()), Times.Exactly(1));
        }
    }
}
