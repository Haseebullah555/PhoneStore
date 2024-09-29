using PhoneStore.Application.Dtos;

namespace PhoneStore.Web.Models
{
    public class PurchaseViewModel
    {
        public PurchaseDto? Purchase { get; set; }
        public SupplierDto? Supplier { get; set; }
    }
}
