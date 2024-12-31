using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        // DbSets represent tables in the database
        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<VesselType> VesselType{ get; set; }
        public DbSet<VesselSubcategory> VesselSubcategory { get; set; }

public DbSet<PortOfRegistry>PortOfRegistry { get; set; }
         
public DbSet<DryDockDue> DryDockDue { get; set; }
    public DbSet<VesselProjects> VesselProjects { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
        
    }
}
