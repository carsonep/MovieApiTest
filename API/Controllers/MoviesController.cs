using System;
using System.IO;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private CinemaDbContext _dbContext;
        public MoviesController(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromForm] Movie movieObj)
        {
            var guid = Guid.NewGuid();
            var filePath = Path.Combine("wwwroot",guid + ".jpg");
            if(movieObj.Image != null)
            {
                var fileStream = new FileStream(filePath, FileMode.CreateNew);
                movieObj.Image.CopyTo(fileStream);
            }
            movieObj.ImageUrl = filePath.Remove(0,7);
            _dbContext.Movies.Add(movieObj);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}