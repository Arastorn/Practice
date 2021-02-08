using System;
using System.ComponentModel.DataAnnotations;

namespace Practice.Api.Models.Digimons
{
    public class UpdateDigimonRequest
    {
        [Required]
        public Guid Id { get; set; } = default!;

        [Required]
        public string Nom { get; set; } = default!;

        [Required]
        public int Niveau { get; set; } = default!;
    }
}