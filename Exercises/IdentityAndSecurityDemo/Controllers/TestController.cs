namespace IdentityAndSecurityDemo.Controllers
{
    using IdentityAndSecurityDemo.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class TestController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public TestController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [Authorize]
        public IActionResult ShowAdmin()
        {
            return this.Ok("Welcome admin");
        }
        public async Task<IActionResult> CreateUser()
        {
            var result = await this.userManager.CreateAsync(new ApplicationUser()
            {
                Email = "stamat@fake.fk",
                UserName = "Stamat",
                EmailConfirmed = true,
                PhoneNumber = "123455543"
            }, "Stamat1@");

            if (!result.Succeeded)
            {
                return this.BadRequest(string
                    .Join("; ", result
                    .Errors
                    .Select(x => x.Description)));
            }

            await this.signInManager.PasswordSignInAsync("Stamat", "Stamat1@", true, false);
            return this.Ok();
        }
        public async Task<IActionResult> CreateRole()
        {
            var result = await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });

            if (!result.Succeeded)
            {
                return this.BadRequest(string
                    .Join("; ", result
                    .Errors
                    .Select(x => x.Description)));
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.userManager.AddToRoleAsync(user, "Admin");

            return this.Ok();
        }
    }
}