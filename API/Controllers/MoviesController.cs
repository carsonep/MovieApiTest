using System.Collections.Generic;
using API.Data;
using API.Models;
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
        public IEnumerable<Movie> Get()
        {
            return _dbContext.Movies;
        }

        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            var movie =_dbContext.Movies.Find(id);

            return movie;
        }

        [HttpPost]
        public void Post([FromBody] Movie movieObj)
        {
            _dbContext.Movies.Add(movieObj);
            _dbContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie movieObj)
        {
            var movie = _dbContext.Movies.Find(id);
            movie.Name = movieObj.Name;
            movie.Language = movieObj.Language;
            _dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           var movie = _dbContext.Movies.Find(id);
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }
        
    }
}