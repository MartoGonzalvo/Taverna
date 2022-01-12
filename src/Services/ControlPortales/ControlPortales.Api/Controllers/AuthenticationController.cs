using ControlPortales.Domain.AggregatesModel.UsuarioAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControlPortales.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration) { _configuration = configuration; }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(TokenDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto, CancellationToken cancellationToken)
        {
            try
            {
                var token = GetJwtToken(new LoginResponseDto { Id = 1, idEmpresa = 1, idSucursal = 1, NombreUsuaurio = loginRequestDto.Usuario });

                var dto = new TokenDto
                {
                    Token = token,
                    idSucursal =1
                };

                return Ok(dto);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

           
        }

        private string GetJwtToken(LoginResponseDto usuario)
        {
            //armo la key y las credenciales
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //armo las claims, las claims son basicamente, un keyvalue
            //esto es lo que se guarda en el User del HttpContext
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim("Empresa", usuario.idEmpresa.ToString()));
            claims.Add(new Claim("Sucursal", usuario.idSucursal.ToString()));
            claims.Add(new Claim("Usuario", usuario.NombreUsuaurio));


            //para traer algun claim usar => User.GetClaim("NombreDelClaim");

            //armo el objeto del token
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMonths(3),
                signingCredentials: credentials);

            //devuelvo la generacion del token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
