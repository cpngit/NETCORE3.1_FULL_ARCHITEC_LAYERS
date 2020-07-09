using System.Threading.Tasks;
using CPN.NetCore.API.Controllers.Core;
using CPN.NetCore.DTO;
using CPN.NetCore.Entity;
using CPN.NetCore.Service.Spec;
using CPN.NetCore.Service.Spec.Core.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CPN.NetCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LnkProfileController :  CRUDControllerBase<ILnkProfileService,LnkProfileDTO, LnkProfile, int>
    {
        public LnkProfileController(ILnkProfileService service):base(service)
        {}
    }
}