using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Company Name is Required!")]
        public string CompanyName { get; set; }
    }
}
