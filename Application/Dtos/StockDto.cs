using PhoneStore.Application.Dtos.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Application.Dtos
{
    public class StockDto :BaseDto
    {
        [Required]
        public int GoodId { get; set; }
        public string? GoodName { get; set; }
        public string CompanyName { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
