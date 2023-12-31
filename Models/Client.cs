﻿using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Ville { get; set; }
    }
}
