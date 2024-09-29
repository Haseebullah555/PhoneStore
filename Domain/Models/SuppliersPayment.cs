using PhoneStore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Domain.Models
{
    public class SuppliersPayment : BaseDomainEntity
    {
        public double PaymentAmount { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }
        public int PurchaseId { get; set; }
        [ForeignKey(nameof(PurchaseId))]
        public Purchase Purchase { get; set; }
    }
}
