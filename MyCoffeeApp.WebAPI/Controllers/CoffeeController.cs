using Microsoft.AspNetCore.Mvc;
using MyCoffeeApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCoffeeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {

        public static List<Coffee> Coffee { get; } = new List<Coffee>();
        // GET: api/Coffee
        [HttpGet]
        public IEnumerable<Coffee> Get()
        {
            return Coffee;
        }

        // GET api/Coffee/5
        [HttpGet("{id}")]
        public Coffee Get(int id)
        {
            return Coffee.FirstOrDefault(c => c.Id == id);
        }

        // POST api/Coffee
        [HttpPost]
        public void Post([FromBody] Coffee value)
        {
            Coffee.Add(value);
        }

        // PUT api/Coffee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Coffee value)
        {
            var coffee = Coffee.FirstOrDefault(c => c.Id == id);
            if (coffee == null)
                return;

            coffee = value;
        }

        // DELETE api/<CoffeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var coffee = Coffee.FirstOrDefault(c => c.Id == id);
            if (coffee == null)
                return;

            Coffee.Remove(coffee);
        }
    }
}
