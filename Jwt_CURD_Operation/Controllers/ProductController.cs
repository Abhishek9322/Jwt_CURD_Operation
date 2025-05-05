using Jwt_CURD_Operation.ModelClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;

namespace Jwt_CURD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbcontex _Context;
        public ProductController(AppDbcontex context)
        {
          _Context = context;
        }
       



        //Access Holl
        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _Context.Product1.ToListAsync());
        }

        //Read data 
        [HttpGet("{id}")]

        
        public async Task<IActionResult> Get (int id)
        {
            var product=await _Context.Product1.FindAsync(id);
            if (product == null) return NotFound();

            return Ok(product);
            
        }

        //Create  API
        [HttpPost]
        [Authorize]
       
        public async Task<IActionResult> Create ( Product product)
        {
            _Context.Product1.Add(product);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = product.Id } , product );
        }

        //Update API
        [HttpPut("{id}")]
        
        public async Task<IActionResult> Update(int id ,Product product)
        {
            if(id !=product.Id) return BadRequest();
            _Context.Entry(product).State= EntityState.Modified;    
            await _Context.SaveChangesAsync();
            return NoContent();

        }
        //Delete API
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _Context.Product1.FindAsync(id);
            if (product == null) return NotFound();
            _Context.Remove(product);
            await _Context.SaveChangesAsync();
            return NoContent();
        }


    }
}
