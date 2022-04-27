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
        public TValue Response { get; set; }
        public ApiResult(TValue value, string description, int statusCode)
        {
            Response = value;
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
            var result =  await _context.Users.ToListAsync();
            var description = "Sucessful Response.";
            var response = new ApiResult<List<User>>(result, description, Response.StatusCode);
            await Response.WriteAsJsonAsync(response);
            return new EmptyResult();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var description = "Successful Response. User Found.";
            if (user == null)
            {
                Response.StatusCode = 404;
                description = "Unsucessful Response. ID not found";
                var result = new ApiResult<User>(user, description, 404);
                await Response.WriteAsJsonAsync(result);

                return new EmptyResult();
            }
 
            
            
            var res = new ApiResult<User>(user, description, 200);
            await Response.WriteAsJsonAsync(res);
            
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
            try
            {
                user.balance = 0.0f;
                user.CardId = 1;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                Response.StatusCode = 201;

                var description = "Sucessful Response. User created";
                var response = new ApiResult<User>(user, description, Response.StatusCode);
                await Response.WriteAsJsonAsync(response);
                return new EmptyResult();

            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                var fail = new ApiResult<User>(null, "Failed Response. Bad Request. " + e.InnerException.Message, Response.StatusCode);
                await Response.WriteAsJsonAsync(fail);
                return new EmptyResult();
            }
           
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

            var card = await _context.Cards.FindAsync(user.CardId);
            if(card != null)
            {
                _context.Cards.Remove(card);
            }
            

            var item = await _context.Items.FirstOrDefaultAsync(i => i.UserId == user.UserId);
            _context.Items.Remove(item);
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
