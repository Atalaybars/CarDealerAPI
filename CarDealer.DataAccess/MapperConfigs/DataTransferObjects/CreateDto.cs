using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.DataAccess.MapperConfigs.DataTransferObjects
{
    public class CreateDto
    {
        [MaxLength(20, ErrorMessage = "Brand name should be 20 characters or less :)")]
        [Required]
        public string Brand { get; set; }

        [MaxLength(20, ErrorMessage = "Model name should be 20 characters or less :)")]
        [Required]
        public string Model { get; set; }
    }
}
