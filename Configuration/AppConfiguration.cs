using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Blog.Configuration
{
    public static class AppConfiguration
    {
        public static void AddDefaultConfiguration(this IApplicationBuilder applicationBuilder, IWebHostEnvironment WebHostenv)
        {
            if (WebHostenv.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseDatabaseErrorPage();
            }
            else
            {
                applicationBuilder.UseExceptionHandler("/Home/Error");
                applicationBuilder.UseHsts();
            }
            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseRouting();

            applicationBuilder.UseAuthentication();
            applicationBuilder.UseAuthorization();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}
