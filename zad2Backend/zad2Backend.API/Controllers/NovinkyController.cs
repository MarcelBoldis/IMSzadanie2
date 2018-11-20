using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zad2Backend.API.Data;
using zad2Backend.API.Models;

namespace zad2Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovinkyController : ControllerBase
    {
        private readonly DataContext context;

        public NovinkyController(DataContext context)
        {
            this.context = context;
        }

        // get api/novinky
        [HttpGet]
        public async Task<IActionResult> GetData (){
            var terminy = await this.context.Novinky.ToListAsync();
            return Ok(terminy);
        }

        // post api/novinky
        [HttpPost]
        public async Task<IActionResult> PostData (Novinky dataObj){
            await this.context.Novinky.AddAsync(dataObj);
            await this.context.SaveChangesAsync();
            return StatusCode(201);
        }

        
    }
}