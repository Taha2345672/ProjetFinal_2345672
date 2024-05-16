using Microsoft.EntityFrameworkCore;
using ProjetFinal.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// Add DbContext
builder.Services.AddDbContext<AviationDBContext>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("AviationDB"));
        // options.UseLazyLoadingProxies();
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=ModeleAvions}/{action=Index}/{id?}"
        );
});

app.MapRazorPages();

app.Run();
