using System.Threading.Tasks;

namespace CPN.NetCore.Repository.Spec.Core.Contract
{
    public interface IUnitOfWork
    {
        int Commit();

        Task<int> CommitAsync();
    }
}