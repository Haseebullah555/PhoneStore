using PhoneStore.Application.Dtos.Common;
using PhoneStore.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PhoneStore.Application.Dtos
{
    public class SalesDto : BaseDto
    {
        [DisplayName("Quantity"),Required(ErrorMessage = "Sale Amount is required!")]
        public int SaleAmount { get; set; }
        [DisplayName("Sale Price"), Required(ErrorMessage = "Sale Price is required!")]
        public int SaleUnitPrice { get; set; }
        [DisplayName("Total Price"), Required(ErrorMessage = "Total Price is required!")]
        public int TotalPrice { get; set; }
        [DisplayName("Paid Amount"), Required(ErrorMessage = "Paid Amount is required")]
        public int PaidAmount { get; set; }
        [DisplayName("Unpaid Amount"), Required(ErrorMessage = "UnPaid Amount is required")]
        public int UnPaidAmount { get; set; }
        [Required(ErrorMessage = "Good Name is required!")]
        [DisplayName("Good Name")]
        public int GoodId { get; set; }
        [DisplayName("Good Name")]
        public string? GoodName { get; set; }
        [DisplayName("Customer Name")]
        public int CustomerId { get; set; }
        [DisplayName("Customer Name")]
        public string? Customer { get; set; }
        [DisplayName("Province Name")]
        public int ProvinceId { get; set; }
        [DisplayName("Province Name")]
        public string? ProvinceName { get; set; }
    }
}
