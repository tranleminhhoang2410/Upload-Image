using TodoList_MySQL.Repository.Interface;

namespace TodoList_MySQL.Service.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Entity> Repository<Entity>() where Entity : class;

        Task<int> Complete();
    }
}
