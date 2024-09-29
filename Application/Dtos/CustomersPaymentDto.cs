using PhoneStore.Application.Dtos.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Application.Dtos
{
    public class CustomersPaymentDto : BaseDto
    {
        [Required(ErrorMessage ="Paid Amount is required"), Display(Name ="Paid Amount")]
        public int PaymentAmount { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Customer")]
        public string? Customer { get; set; }
        public int SalesId { get; set; }
        [Display(Name = "Sales")]
        public string? Sales { get; set; }
    }
}
