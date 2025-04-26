using futbol.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace futbol.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Player> DbSetPlayer {get; set;}
    public DbSet<Team> DbSetTeam {get; set;}
    public DbSet<PlayerTeam> DbSetPlayerTeam {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlayerTeam>()
            .HasKey(pt => new { pt.PlayerId, pt.TeamId }); 
            
        modelBuilder.Entity<PlayerTeam>()
            .HasOne<Player>() 
            .WithMany()       
            .HasForeignKey(pt => pt.PlayerId); 


        modelBuilder.Entity<PlayerTeam>()
            .HasOne<Team>()   
            .WithMany()       
            .HasForeignKey(pt => pt.TeamId);
    }

}
