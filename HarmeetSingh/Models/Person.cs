using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarmeetSingh.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Please enter valid name")]
        [Display(Name = "Name")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter valid amount")]
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public Guid? ID { get; set; }
    }
}
