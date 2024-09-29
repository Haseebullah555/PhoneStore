using PhoneStore.Application.Dtos.Common;
using PhoneStore.Domain.Common;
using PhoneStore.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Application.Dtos
{
    public class CustomerDto : BaseDto
    {
        [Display(Name ="Customer Name"),Required(ErrorMessage = "Customer Name is Required!")]
        public string CustomerName { get; set; }
        [Display(Name = "Phone Number"), Required(ErrorMessage = "Customer Phone Number is Required!")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Address")]
        public string? Address { get; set; }
        [Display(Name = "Province")]
        public int ProvinceId { get; set; }
        public string? Province { get; set; }
        public List<SalesDto> Sales { get; set; }
    }
}
