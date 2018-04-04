using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityCRUD.Models
{
    [Table("tblDetails")]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(30, ErrorMessage = "Name must be 4 - 30 characters!", MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "City is required!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required!")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Mobile is required!")]
        [StringLength(10, ErrorMessage = "Mobile number must be 10 digits only!", MinimumLength = 10)] 
        public string Mobile { get; set; }
    }
}