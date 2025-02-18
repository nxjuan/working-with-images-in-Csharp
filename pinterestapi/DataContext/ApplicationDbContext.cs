using Microsoft.EntityFrameworkCore;
using pinterestapi.Model;

namespace pinterestapi.DataContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<PostModel> Posts { get; set; }
}