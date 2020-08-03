using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{

    [Authorize]
    [Route("[controller]")]
    [ApiController]

    // Here ControllerBase is A base class for an MVC controller without view support while if we extend from Controller then Controller is a A base class for an MVC controller with view support
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context; // _ is only our preference

        public ValuesController(DataContext context)
        {
            _context = context;

        }

        //https://localhost:5000/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);  // Ok returns also http 200 code 
        }

        //https://localhost:5000/values/4
        [AllowAnonymous]  // We assigned this just for example
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value); 
        }

    }
}
