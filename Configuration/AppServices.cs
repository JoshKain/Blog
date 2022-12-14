using Blog.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Blog.Configuration
{
    public static class AppservicesCollection
    {
        public static void AddDefaultServices(this IServiceCollection servicesCollection, IConfiguration configuration)
        {
            servicesCollection.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")));
            servicesCollection.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            servicesCollection.AddControllersWithViews().AddRazorRuntimeCompilation();
            servicesCollection.AddRazorPages();
        }
    }
}
