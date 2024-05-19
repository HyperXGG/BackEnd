using WineShopApplication.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WineShopApplication.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            IdentityUser? user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName), //ClaimTypes sono elenchi di nomi prefatti non ufficiali
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //JwtRegisteredClaimNames sono ufficiali di JWT
                };

                foreach (string userRole in userRoles)
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));

                var token = GetToken(authClaims); //Ancora un oggetto, una preparazione del token

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token), //Così diventa un testo crittografato
                    expiration = token.ValidTo,
                    role = userRoles.Count() == 1 ? UserRoles.USER : UserRoles.ADMIN
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            IdentityUser? userExists = await _userManager.FindByNameAsync(model.UserName);

            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response 
                { 
                    Status = "Error", 
                    Message = "User already exists"
                });

            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = "User creation failed! Please check user details and try again."
                });

            if (!await _roleManager.RoleExistsAsync(UserRoles.USER))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.USER));

            if (await _roleManager.RoleExistsAsync(UserRoles.USER))
                await _userManager.AddToRoleAsync(user, UserRoles.USER);

            return Ok(new Response
            {
                Status = "Success",
                Message = "User created successfully"
            });
        }

        [HttpPost]
        [Route("Register-Admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);

            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = "User already exists"
                });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = "User creation failed! Please check user details and try again."
                });

            if (!await _roleManager.RoleExistsAsync(UserRoles.ADMIN))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.ADMIN));

            if (!await _roleManager.RoleExistsAsync(UserRoles.USER))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.USER));

            if (await _roleManager.RoleExistsAsync(UserRoles.ADMIN))
                await _userManager.AddToRoleAsync(user, UserRoles.ADMIN);

            if (await _roleManager.RoleExistsAsync(UserRoles.USER))
                await _userManager.AddToRoleAsync(user, UserRoles.USER);

            return Ok(new Response
            {
                Status = "Success",
                Message = "User created successfully"
            });
        }

        //Claim = dichiarazioni di autorizzazione allegate ad un token
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken    
            (
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
