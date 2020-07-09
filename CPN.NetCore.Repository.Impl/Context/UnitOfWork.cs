using System.Threading.Tasks;
using CPN.NetCore.Repository.Spec.Core.Contract;

namespace CPN.NetCore.Repository.Impl.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ApplicationDbContext Context { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}