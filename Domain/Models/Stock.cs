using PhoneStore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Domain.Models
{
    public class Stock : BaseDomainEntity
    {
        [Required]
        public int GoodId { get; set; }

        [ForeignKey(nameof(GoodId))]
        public Goods? Good { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
