using CPN.NetCore.DTO.Core;
using System.ComponentModel.DataAnnotations;

namespace CPN.NetCore.DTO
{
    public class LnkProfileDTO : BaseDTO<int>
    {

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public bool Status { get; set; }
    }
}