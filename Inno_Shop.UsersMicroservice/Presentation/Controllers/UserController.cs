using Inno_Shop.Services.Users.Domain.Models.Entities;
using Inno_Shop.UsersMicroservice.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inno_Shop.UsersMicroservice.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repository.GetAllUsersAsync();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();
            
            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                await _repository.AddUserAsync(user);
                await _repository.SaveAsync();
                return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            try
            {
                var userFormDb = await _repository.GetUserByNameAsync(user.Name);

                if (userFormDb == null)
                    return NotFound(user.Id);

                userFormDb.Name = user.Name;
                userFormDb.Email = user.Email;
                await _repository.SaveAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            await _repository.DeleteUserAsync(id);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
