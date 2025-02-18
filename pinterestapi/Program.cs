using Microsoft.EntityFrameworkCore;
using pinterestapi.DataContext;
using pinterestapi.Service.PostService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddScoped<IPostInterface, PostService>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("apicors", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();

app.UseCors("apicors");

app.Run();

