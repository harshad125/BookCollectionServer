using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCollection.Models;

namespace MyCollection.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyCollectionDBContext _context;
        private readonly IMapper _mapper;
        public UsersController(MyCollectionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        // GET: api/Users
       /* [HttpGet,Route("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }*/
       /* [HttpPost]
        [Route("Registration")]
        public async Task<User?> Registration(User user)
        {
            var user1 = (_context.Users?.Any(e => e.Email == user.Email)).GetValueOrDefault();
            if (user1 == null)
            {
                return null;
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
            
        }*/
       /* [HttpPost]
        [Route("Login")]
        public async Task<User?> Login(Login login)
        {
            var user=await _context.Users.FirstOrDefaultAsync(e=>e.Email == login.Email);
            if (user == null)
            {
                return user;
            }
            else if(login.Password!=user.Password)
            {
                return user;
            }
            return user;
        }*/

        // GET: api/Users/
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUser()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            long id = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = await _context.Users.FindAsync(id);
            UserDto userDto = _mapper.Map<UserDto>(user);
            userDto.Books = await _context.Books.Where(e => e.userid == id).ToListAsync();
            if (userDto == null)
            {
                return NotFound();
            }

            return userDto;
        }

        // PUT: api/Users/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutUser(User user)
        {
            long id = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (id != user.id)
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'MyCollectionDBContext.Users'  is null.");
          }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            long id = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(long id)
        {
            return (_context.Users?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
