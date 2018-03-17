using Api.App.Bank.Persistance.Entities;
using Api.App.Infrastructure.Persistance.Interface;

namespace Api.App.Bank.Persistance.Repositories
{
    public interface IPaymentRepository
          : IRepository
    {
        void Save(Payment record);
    }
}
