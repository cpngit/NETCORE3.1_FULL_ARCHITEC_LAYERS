using CPN.NetCore.DTO;
using CPN.NetCore.Entity;
using CPN.NetCore.Service.Spec.Core.Contract;

namespace CPN.NetCore.Service.Spec
{
 public interface ILnkProfileService : ICRUDDomainService<LnkProfileDTO,LnkProfile, int>
 {}
}