using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Shop
    {
        [Column("ShopId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Shop name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Shop address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for rhe Address is 60 characters")]
        public string Address { get; set; }
        public int Budget { get; set; }
    }
}
