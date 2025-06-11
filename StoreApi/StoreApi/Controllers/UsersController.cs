using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;
using StoreApi.Models;
using StoreApi.Repositories;
using StoreApi.Repositories.Interfaces;
using StoreApi.Service;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController(IUserRepository userRepository) : ControllerBase
    {


        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers() => await userRepository.GetAllAsync();

        [HttpGet("{Email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await userRepository.GetUserByEmail(email);
            if (user == null) { return NotFound(); }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            await userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetUserByEmail), new { email = user.Email }, user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id) { return BadRequest(); }
            await userRepository.UpdateAsync(id, user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null) { return NotFound(); }
            await userRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
