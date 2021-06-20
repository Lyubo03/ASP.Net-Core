namespace Stopify.App
{
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Stopify.Data;
    using Stopify.Data.Models;
    using Stopify.Services;
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;
    using Stopify.Web.InputModels;
    using Stopify.Web.ViewModels.Home.Index;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StopifyDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<StopifyUser, IdentityRole>()
                .AddEntityFrameworkStores<StopifyDbContext>()
                .AddDefaultTokenProviders();

            var cloudinaryCredentials = new Account(
                this.Configuration["Cloudinary:CloudName"],
                this.Configuration["Cloudinary:ApiKey"],
                this.Configuration["Cloudinary:ApiSecret"]
                );

            var cloudinaryUtility = new Cloudinary(cloudinaryCredentials);
            services.AddSingleton(cloudinaryUtility);

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IReceiptService, ReceiptService>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequiredLength = 3;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            AutoMapperConfig.RegisterMappings(
                    typeof(ProductCreateInputModel).GetTypeInfo().Assembly,
                    typeof(ProductHomeViewModel).GetTypeInfo().Assembly,
                    typeof(ProductServiceModel).GetTypeInfo().Assembly);

            app.UseRouting();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<StopifyDbContext>())
                {
                    context.Database.Migrate();

                    if (!context.Roles.Any())
                    {
                        context.Roles.AddAsync(new IdentityRole
                        {
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });

                        context.Roles.Add(new IdentityRole
                        {
                            Name = "User",
                            NormalizedName = "USER"
                        });


                    }
                    if (!context.OrderStatuses.Any())
                    {
                        context.OrderStatuses.Add(new OrderStatus
                        {
                            Name = "Active"
                        });

                        context.OrderStatuses.Add(new OrderStatus
                        {
                            Name = "Completed"
                        });

                        context.SaveChanges();
                    }
                }
            }

            app.UseStatusCodePagesWithRedirects("/Identity/Account/Register");
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}