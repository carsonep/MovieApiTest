using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public double Rating { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
    }
}