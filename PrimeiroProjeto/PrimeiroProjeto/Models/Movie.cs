﻿using System.ComponentModel.DataAnnotations;

namespace PrimeiroProjeto.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
