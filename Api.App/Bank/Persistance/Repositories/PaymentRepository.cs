using Api.App.Bank.Persistance.Entities;
using Api.App.Infrastructure.Persistance.Interface;

namespace Api.App.Bank.Persistance.Repositories
{
    public class PaymentRepository
        : IPaymentRepository
    {
        protected IPersistancSession _session;

        public PaymentRepository(IPersistancSession session)
        {
            this._session = session;
        }

        public void Save(Payment record)
        {
            this._session.Write(record);
        }
    }
}