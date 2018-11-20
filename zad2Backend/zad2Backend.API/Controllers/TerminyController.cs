using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zad2Backend.API.Data;
using zad2Backend.API.Models;

namespace zad2Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminyController : ControllerBase
    {
        private readonly DataContext context;

        public TerminyController(DataContext context)
        {
            this.context = context;
        }

        // get api/terminy
        [HttpGet]
        public async Task<IActionResult> GetData (){
            var terminy = await this.context.Terminy.ToListAsync();
            return Ok(terminy);
        }

        // post api/terminy
        [HttpPost]
        public async Task<IActionResult> PostData (Terminy dataObj){
            await this.context.Terminy.AddAsync(dataObj);
            await this.context.SaveChangesAsync();
            return StatusCode(201);
        }

    }
}