using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    // Dotarcie do strony którą obsługuje ten kontroler:  http://localhost:5000/api/values
    // localhost bo serwer jest tam gdzie klient, 5000 bo to port kestrela, api bo route linijka nizej, values bo bierze 
    // pod uwage slowo przed slowem "controller"
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        // Jesli request http to get, uruchomi sie blok get i tak dalej
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // http://localhost:5000/api/values uruchomi tą metodę!
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = _context.Values.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
