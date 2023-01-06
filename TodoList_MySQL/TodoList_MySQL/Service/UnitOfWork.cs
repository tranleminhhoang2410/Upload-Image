using System.Collections;
using TodoList_MySQL.Data;
using TodoList_MySQL.Repository;
using TodoList_MySQL.Repository.Interface;
using TodoList_MySQL.Service.Interface;

namespace TodoList_MySQL.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private Hashtable repositories;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public IGenericRepository<Entity> Repository<Entity>() where Entity : class
        {
            if (repositories == null) repositories = new Hashtable();

            var type = typeof(Entity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(Entity)), context);

                repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<Entity>)repositories[type];
        }

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
