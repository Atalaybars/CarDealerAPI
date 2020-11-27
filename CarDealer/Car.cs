using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Entities
{
    public class Car
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "Brand name should be 20 characters or less :)")]
        [Required]
        public string Brand { get; set; }

        [MaxLength(20, ErrorMessage = "Model name should be 20 characters or less :)")]
        [Required]
        public string Model { get; set; }
    }
}
