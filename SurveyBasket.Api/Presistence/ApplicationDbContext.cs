using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurveyBasket.Api.Presistence.EntitiesConfigurations;
using System.Reflection;

namespace SurveyBasket.Api.Presistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : 
    IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Poll> Polls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly() );

        base.OnModelCreating(modelBuilder);
    }
}
