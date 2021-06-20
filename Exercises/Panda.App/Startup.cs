using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Panda.Data;
using Panda.Domain;
using Panda.Services.Package;
using Panda.Services.Receipt;
using Panda.Services.User;
using System.Linq;

namespace Panda.App
{
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 2;
                options.Password.RequiredUniqueChars = 0;

                options.User.RequireUniqueEmail = true;
            });

            services.AddDbContext<PandaDbContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<PandaUser, PandaUserRole>()
                .AddEntityFrameworkStores<PandaDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IPackageService, PackageService>();
            services.AddTransient<IReceiptService, ReceiptService>();
            services.AddTransient<IUserService, UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<PandaDbContext>())
                {
                    context.Database.Migrate();

                    if (!context.Roles.Any())
                    {
                        context.Roles.Add(new PandaUserRole { Name = "Admin", NormalizedName = "ADMIN" });
                        context.Roles.Add(new PandaUserRole { Name = "User", NormalizedName = "User" });
                    }

                    if (!context.PackageStatuses.Any())
                    {
                        context.PackageStatuses.Add(new PackageStatus { Name = "Pending" });
                        context.PackageStatuses.Add(new PackageStatus { Name = "Shipped" });
                        context.PackageStatuses.Add(new PackageStatus { Name = "Delivered" });
                        context.PackageStatuses.Add(new PackageStatus { Name = "Acquired" });
                    }

                    context.SaveChanges();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}