using PhoneStore.Application.Dtos.Common;
using PhoneStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Application.Dtos
{
    public class GoodsDto : BaseDto
    {
        [Display(Name ="Good Name"),Required(ErrorMessage ="Good Name is required!")]
        public string GoodName { get; set; }
        [Display(Name = "Company Name"), Required(ErrorMessage = "Company Name is required!")]
        public int CompanyId { get; set; }
        public string? Company { get; set; }
    }
}
