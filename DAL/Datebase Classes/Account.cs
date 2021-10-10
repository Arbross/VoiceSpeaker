using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [NotMapped]
        public string FullName => $"{Name} {Surname}";
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd}"), Required]
        public DateTime PublishDate { get; set; }
        [EmailAddress, Required]
        public string Mail { get; set; }
        [MaxLength(20), Required]
        public string Phone { get; set; }
    }
}
