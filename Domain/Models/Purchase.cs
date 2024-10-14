using PhoneStore.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Domain.Models
{
    public class Purchase : BaseDomainEntity
    {
        [Required(ErrorMessage = "Purchase Price is required!")]
        public int UnitPurchasePrice { get; set; }
        [Required(ErrorMessage = "Total Price is required")]
        public int SubTotal { get; set; }
        [Required(ErrorMessage = "Purchase Amount is required!")]
        public int PurchaseAmount { get; set; }
        [Required(ErrorMessage = "Good Name is required!")]
        public int GoodId { get; set; }
        [ForeignKey(nameof(GoodId))]
        public Goods? Goods { get; set; }
        [Required(ErrorMessage = "Supplier Name is required!")]
        public int SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }

    }
}
