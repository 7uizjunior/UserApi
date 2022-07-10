using Microsoft.AspNetCore.Mvc;
using UserApi.Data.DTOs;
using UserApi.Interfaces;
using UserApi.Models;

namespace UserApi.Controller
{
    [ApiController]
    [Route("v1/usuarios")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]

        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO dto)
        {
            try
            {
                var response = await _service.Create(dto);
                return CreatedAtAction(nameof(GetUserById), new { id = response.Id }, response);
            }
            catch (BadHttpRequestException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            try
            {
                await _service.Delete(id);
                return NoContent();
            }

            catch (BadHttpRequestException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] User user)
        {
            try
            {
                await _service.Update(id, user);
                return NoContent();
            }

            catch (BadHttpRequestException ex)
            {
                return StatusCode(ex.StatusCode);
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var response = _service.GetById(id);
            return response == null
                ? NotFound()
                : Ok(response);
        }
    }
}