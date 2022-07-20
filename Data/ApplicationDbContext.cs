using Microsoft.EntityFrameworkCore;
using OmegaParts.Models;

namespace OmegaParts.Data;

public class ApplicationDbContext :DbContext
{
    public DbSet<Clutch_Model> Clutches { get; set; }
    
    public DbSet<Order_Model> Orders { get; set; }
    
    public DbSet<Head_Gasket_Model> Head_Gasket { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
}