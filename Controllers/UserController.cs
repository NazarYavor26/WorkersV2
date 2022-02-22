using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkersV2.DbContexts;
using WorkersV2.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkersV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        AppDbContext db;
        public UsersController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody]User user)
        {

            var updatedUser = await db.Users.FindAsync(id);
            if(user != null)
            {
                updatedUser.Name = user.Name;
                updatedUser.Age = user.Age;

                await db.SaveChangesAsync();
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }







        /* Work only if we write id in body*/
        /* [HttpPut]
         public async Task<ActionResult<User>> Put(User user)
         {
             if (user == null)
             {
                 return BadRequest();
             }
             if (!db.Users.Any(x => x.Id == user.Id))
             {
                 return NotFound();
             }

             db.Update(user);
             await db.SaveChangesAsync();
             return Ok(user);

         }*/
    }
}
