using PhoneStore.Application.Dtos.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Application.Dtos
{
    public class SupplierPurchaseDto : BaseDto
    {
        [Display(Name = "Unit Purchase Price"), Required(ErrorMessage = "Purchase Price is required!")]
        public double UnitPurchasePrice { get; set; }
        [Display(Name = "Total Price"), Required(ErrorMessage = "Total Price is required")]
        public double TotalPrice { get; set; }
        [Display(Name = "Purchase Quantity"), Required(ErrorMessage = "Purchase Amount is required!")]
        public int PurchaseAmount { get; set; }
        [Display(Name = "Good Name"), Required(ErrorMessage = "Good Name is required!")]
        public int GoodId { get; set; }
        public string? Goods { get; set; }
        [Display(Name = "Supplier Name"), Required(ErrorMessage = "Supplier Name is required!")]
        public int SupplierId { get; set; }
        public string? Supplier { get; set; }
        [Display(Name = "Paid Amount"), Required(ErrorMessage = "Paid Amount is required")]
        public double PaidAmount { get; set; }
        [Display(Name = "UnPaid Amount"), Required(ErrorMessage = "UnPaid Amount is required")]
        public double UnPaidAmount { get; set; }
        public string? CompanyName { get; set; }
    }
}
