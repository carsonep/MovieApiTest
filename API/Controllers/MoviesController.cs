using System.Collections.Generic;
using API.Data;
using API.Models;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Movies);
        }

        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            var movie =_dbContext.Movies.Find(id);

            return movie;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie movieObj)
        {
            _dbContext.Movies.Add(movieObj);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movieObj)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound("No Record found against this Id");
            }
            else {
                movie.Name = movieObj.Name;
                movie.Language = movieObj.Language;
                _dbContext.SaveChanges();
                return Ok("Record Updated Successfully");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var movie = _dbContext.Movies.Find(id);
           if (movie == null)
            {
                return NotFound("No Record found against this Id");
            } else {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
                return Ok("Record Deleted Successfully");
            }
            
        }
        
    }
}