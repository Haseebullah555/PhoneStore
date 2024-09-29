using PhoneStore.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Domain.Models
{
    public class Sales : BaseDomainEntity
    {
        [Required(ErrorMessage ="Sale Amount is required!")]
        public int SaleAmount { get; set; }
        [Required(ErrorMessage = "Sale Price is required!")]
        public int SaleUnitPrice { get; set; }
        [Required(ErrorMessage = "Total Price is required!")]
        public int TotalPrice { get; set; }
        [Required(ErrorMessage = "Paid Amount is required")]
        public int PaidAmount { get; set; }
        [Required(ErrorMessage = "UnPaid Amount is required")]
        public int UnPaidAmount { get; set; }
        [Required(ErrorMessage = "Good Name is required!")]
        public int GoodId { get; set; }
        [ForeignKey(nameof(GoodId))]
        public Goods? Goods { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }


    }
}
