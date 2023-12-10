using Inno_Shop.Services.Users.Domain.Models.Entities;
using Inno_Shop.UsersMicroservice.Application.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Inno_Shop.UsersMicroservice.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService) =>
            _userService = userService;
        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();
            
            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                await _userService.AddAsync(user);
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
                var userFormDb = await _userService.GetByIdAsync(user.Id);

                if (userFormDb == null)
                    return NotFound(user.Id);

                userFormDb.Name = user.Name;
                userFormDb.Email = user.Email;
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            await _userService.DeleteAsync(id);

            return NoContent();
        }
    }
}
