using AF.ECommerce.Domain.Entities;

namespace AF.ECommerce.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> : IRepository<T> where T : Entity
    {
    }
}
