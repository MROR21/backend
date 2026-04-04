using Microsoft.AspNetCore.Mvc;
using Desafio_root.Application.DTOs;
using Desafio_root.Application.Services;

namespace Desafio_root.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO dto)
        {
            try
            {
                var response = await _userService.LoginOrRegisterAsync(dto);

                return Ok(response);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Erro = ex.Message, Detalhe = ex.InnerException?.Message });
            }
        }
    }
}
