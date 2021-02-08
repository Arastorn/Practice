using System.ComponentModel.DataAnnotations;

namespace Practice.Api.Models.Digimons
{
    public class CreateDigimonRequest
    {
        [Required]
        public string Nom { get; set; } = default!;

        [Required]
        public int Niveau { get; set; } = default!;
    }
}