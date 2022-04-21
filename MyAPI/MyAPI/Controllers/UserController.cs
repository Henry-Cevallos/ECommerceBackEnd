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
    public class ApiResult<TValue>
    {

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("statusDescription")]
        public string StatusDescription { get; set; }

        [JsonProperty("response")]
        public TValue Value { get; set; }
        public ApiResult(TValue value, string description, int statusCode)
        {
            Value = value;
            StatusDescription = description;
            StatusCode = statusCode;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        

        private readonly MyAPIDBContext _context;

        public UserController(MyAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var description = "Successful Response";
            if (user == null)
            {
                //Response.StatusCode = 404;
                description = "Unsucessful Response. ID not found";
                
                return NotFound();
            }
 
            
            
            var res = new ApiResult<User>(user, description, 200);
            await Response.WriteAsJsonAsync(res);
            //await Response.CompleteAsync();
            return new EmptyResult();
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
