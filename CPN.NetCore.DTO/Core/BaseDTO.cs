using System.ComponentModel.DataAnnotations.Schema;

namespace CPN.NetCore.DTO.Core
{
    public abstract class BaseDTO<TId> 
    {
         public TId Id { get; set; }
    }
}
