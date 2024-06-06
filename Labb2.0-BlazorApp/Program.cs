using Labb2._0_BlazorApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace Labb2._0_BlazorApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<YourDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"))
            );
			

            // Add services to the container.
            builder.Services.AddRazorPages();
			builder.Services.AddServerSideBlazor();
			
			/*builder.Services.AddDbContext<YourDbContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Felixzoon;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))*/;

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
			}

            using (var scope = app.Services.CreateScope())
            {
				var services = scope.ServiceProvider;
                
                
                    var context = services.GetRequiredService<YourDbContext>();
                    context.Database.Migrate();
                    
                

            }

     //      var context = app.Services.GetRequiredService<YourDbContext>();
		   //context.Database.Migrate();


         

			app.UseStaticFiles();

			app.UseRouting();

			app.MapBlazorHub();
			app.MapFallbackToPage("/_Host");

            //var mydb = new YourDbContext();
            //mydb.Database.Migrate();

            app.Run();
           

        }
	}
}