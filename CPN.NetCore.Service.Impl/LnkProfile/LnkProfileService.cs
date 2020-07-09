using AutoMapper;
using CPN.NetCore.DTO;
using CPN.NetCore.Entity;
using CPN.NetCore.Repository.Spec.Core.Contract;
using CPN.NetCore.Service.Impl.Core;
using CPN.NetCore.Service.Spec;

namespace CPN.NetCore.Service.Impl
{
public class LnkProfileService : CRUDDomainService<LnkProfileDTO,LnkProfile, int>, ILnkProfileService
{
    public LnkProfileService(IUnitOfWork unitOfWork, ICRUDDomainRepository<LnkProfile, int> repository, 
        IMapper mapper) : base (unitOfWork,repository,mapper)
    {}
}
}