using PhoneStore.Application.Dtos.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Application.Dtos
{
    public class SuppliersPaymentDto : BaseDto
    {
        [Display(Name = "Paid Amount")]
        public double PaymentAmount { get; set; }
        public int SupplierId { get; set; }
        [Display(Name = "Supplier")]
        public string Supplier { get; set; }
        public int PurchaseId { get; set; }
        [Display(Name ="Purcase")]
        public string Purchase { get; set; }
    }
}
