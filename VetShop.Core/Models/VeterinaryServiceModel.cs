using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetShop.Core.Models
{
    public class VeterinaryServiceModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Specialty { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string FullName { get; set; } = null!;
    }
}
