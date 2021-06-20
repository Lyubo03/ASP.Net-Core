namespace Message.App.Controllers
{
    using Message.App.Jwt;
    using Message.App.Models;
    using Message.Data;
    using Message.Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class UserController : ApiController
    {
        private readonly JwtSettings jwtSettings;
        private readonly MessageDbContext context;

        public UserController(JwtSettings jwtSettings,
            MessageDbContext context)
        {
            this.jwtSettings = jwtSettings;
            this.context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            var user = new User
            {
                Username = model.Username,
                Password = model.Password
            };

            await this.context.Users.AddAsync(user);

            await this.context.SaveChangesAsync();
            return this.Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]UserBindingModel model)
        {
            var user = await this.context.Users
                .SingleOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

            if (model == null)
            {
                return this.BadRequest("Username or password is Invalid");
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return this.Ok(token);
        }

    }
}