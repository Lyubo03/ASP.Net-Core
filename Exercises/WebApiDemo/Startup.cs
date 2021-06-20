namespace WebApiDemo
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Linq;
    using System.Text;
    using WebApiDemo.Configuration;
    using WebApiDemo.Data;
    using WebApiDemo.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var jwtSettingsSection =
                Configuration
                .GetSection("jwtSettings");
            services.Configure<JwtSettings>(jwtSettingsSection);

            var settings = jwtSettingsSection.Get<JwtSettings>();
            var key = Encoding.UTF8.GetBytes(settings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services
                .AddDbContext<ApplicationDbContext>(options => options
            .UseSqlServer(@"Server=DESKTOP-2RO7KG1\SQLEXPRESS;Database=Cars;Integrated Security=true;"));
            services.AddTransient<ApplicationDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var context = new ApplicationDbContext();
            context.Database.EnsureCreated();


            if (!context.Cars.Any())
            {
                context.Cars.Add(new Car
                {
                    Model = "Volvo s60",
                    Year = 2005,
                    Color = Color.Black,
                });
                context.Cars.Add(new Car
                {
                    Model = "Volvo s50",
                    Year = 2003,
                    Color = Color.Gray,
                }); context.Cars.Add(new Car
                {
                    Model = "Volvo s40",
                    Year = 2002,
                    Color = Color.Blue,
                }); context.Cars.Add(new Car
                {
                    Model = "Volvo s30",
                    Year = 2001,
                    Color = Color.Red,
                });

                context.SaveChanges();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}