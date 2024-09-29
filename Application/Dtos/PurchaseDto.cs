using PhoneStore.Application.Dtos.Common;
using PhoneStore.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Application.Dtos
{
    public class PurchaseDto : BaseDto
    {
        [Display(Name ="Unit Purchase Price"),Required(ErrorMessage = "Purchase Price is required!")]
        public int UnitPurchasePrice { get; set; }
        [Display(Name ="Total Price"),Required(ErrorMessage = "Total Price is required")]
        public int TotalPrice { get; set; }
        [Display(Name = "Purchase Quantity"), Required(ErrorMessage = "Purchase Amount is required!")]
        public int PurchaseAmount { get; set; }
        [Display(Name = "Good Name"), Required(ErrorMessage = "Good Name is required!")]
        public int GoodId { get; set; }
        public string? Goods { get; set; }
        [Display(Name = "Supplier Name"), Required(ErrorMessage = "Supplier Name is required!")]
        public int SupplierId { get; set; }
        public string? Supplier { get; set; }
        [Display(Name = "Paid Amount"), Required(ErrorMessage = "Paid Amount is required")]
        public int PaidAmount { get; set; }
        [Display(Name = "UnPaid Amount"), Required(ErrorMessage = "UnPaid Amount is required")]
        public int UnPaidAmount { get; set; }
        public string? CompanyName { get; set; }

    }
}
