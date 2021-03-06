#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;
using Newtonsoft.Json;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly MyAPIDBContext _context;

        public ItemController(MyAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var result = await _context.Items.ToListAsync();
            Response.StatusCode = 200;
            var response = new ApiResult<List<Item>>(result, "Sucessful Response.", 200);
            await Response.WriteAsJsonAsync(response);

            return new EmptyResult();
            
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                Response.StatusCode = 404;
                var result = new ApiResult<Item>(item, "Unsucessful Response. ID not found", 404);
                await Response.WriteAsJsonAsync(result);

                return new EmptyResult();
            }

            var res = new ApiResult<Item>(item, "Successful Response. User found.", 200);
            await Response.WriteAsJsonAsync(res);

            return new EmptyResult();
        }

        // PUT: api/Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            try
            {
                
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                Response.StatusCode = 201;

                var description = "Sucessful Response. Item created";
                var response = new ApiResult<Item>(item, description, Response.StatusCode);
                await Response.WriteAsJsonAsync(response);
                return new EmptyResult();

            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                var fail = new ApiResult<Item>(null, "Failed Response. Bad Request. " + e.InnerException.Message, Response.StatusCode);
                await Response.WriteAsJsonAsync(fail);
                return new EmptyResult();
            }
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                Response.StatusCode = 404;
                var failResult = new ApiResult<Item>(null, "Unsuccessful Response. Invalid ID passed", 404);
                await Response.WriteAsJsonAsync(failResult);
                return new EmptyResult();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            Response.StatusCode = 200;
            var successfulResult = new ApiResult<Item>(item, "Sucessful Response. Item Deleted", 200);
            await Response.WriteAsJsonAsync(successfulResult);
            return new EmptyResult();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
