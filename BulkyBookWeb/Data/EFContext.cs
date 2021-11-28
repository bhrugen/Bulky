
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data { 
public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories {  get; set; }
}
}