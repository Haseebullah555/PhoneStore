using PhoneStore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Domain.Models
{
    public class SupplierLoans : BaseDomainEntity
    {
        public int UnpaidAmount { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }
    }
}
