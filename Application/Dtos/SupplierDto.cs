using PhoneStore.Application.Dtos.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Application.Dtos
{
    public class SupplierDto : BaseDto
    {
        [Required(ErrorMessage = "Supplier Name Can't be empty")]
        public string SupplierName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public List<PurchaseDto> Purchases { get; set; }
    }
}
