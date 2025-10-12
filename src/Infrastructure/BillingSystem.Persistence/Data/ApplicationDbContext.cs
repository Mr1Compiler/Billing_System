using BillingSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BillingSystem.Persistence.FluentConfig;
using Microsoft.AspNetCore.Identity;

namespace BillingSystem.Persistence.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql(
    //         "Host=localhost;Port=5432;Database=BillingSystem;Username=postgres;Password=abcSql_00;");
    // }
    //
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }
    public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserConfiguration());
        builder.ApplyConfiguration(new CustomerConfiguration());
        builder.ApplyConfiguration(new CustomerSubscriptionConfiguration());
        builder.ApplyConfiguration(new SubscriptionPlanConfiguration());
        builder.ApplyConfiguration(new TenantConfiguration());
    }
    

}