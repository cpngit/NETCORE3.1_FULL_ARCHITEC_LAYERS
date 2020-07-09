
namespace CPN.NetCore.Entity.Core.Contract
{
    public interface IDomain<TId>
    {
        TId Id { get; set; }
    }
}