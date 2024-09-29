using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Application.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        [Display(Name ="Company Name"),Required(ErrorMessage = "Company Name is Required!")]
        public string CompanyName { get; set; }
    }
}
