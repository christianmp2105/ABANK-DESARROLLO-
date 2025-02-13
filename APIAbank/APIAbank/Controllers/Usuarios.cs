using Core.APIAbank.Interfaces;
using Core.APIAbank.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIAbank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Usuarios : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly JwtService _jwtService;

        public Usuarios(IUsuarioRepository usuarioRepository, JwtService jwtService)
        {
            _usuarioRepository = usuarioRepository;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string telefono, string contraseña)
        {
            try
            {
                if (telefono != "" && contraseña != "")
                {
                    var users = await _usuarioRepository.GetAllAsync();
                    var usuarioencontrado = users.FirstOrDefault(u => u.telefono == telefono && u.contraseña == contraseña);
                    if (usuarioencontrado == null)
                    {
                        return NotFound("Los datos no coinciden con ningun usuario");
                    }
                    var token = _jwtService.GenerateJwtToken(contraseña);
                    return Ok(new { usuarioencontrado, Token = token, Type = "bearer" });
                    //return Ok(usuarioencontrado);
                }
                return Unauthorized("Credenciales incorrectas");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _usuarioRepository.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _usuarioRepository.GetByIdAsync(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario usuario)
        {
            try
            {
                usuario.fechanacimiento = DateTime.Now;
                usuario.fechamodificacion = DateTime.Now;
                await _usuarioRepository.AddAsync(usuario);
                return CreatedAtAction(nameof(GetById), new { id = usuario.id }, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Usuario usuario)
        {
            try
            {
                var existingUser = await _usuarioRepository.GetByIdAsync(id);
                if (existingUser == null)
                    return NotFound();

                usuario.id = id;
                usuario.fechamodificacion = DateTime.Now;
                await _usuarioRepository.UpdateAsync(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetByIdAsync(id);
                if (usuario == null)
                    return NotFound();

                await _usuarioRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }

    }
}
