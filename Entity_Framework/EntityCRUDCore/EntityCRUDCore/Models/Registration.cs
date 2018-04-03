using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCRUDCore.Models
{
    [Table("tblRegistration")]
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is required!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Mobile is required!")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "City is required!")]
        public string City { get; set; }
    }
}
