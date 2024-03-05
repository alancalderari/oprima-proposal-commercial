using Microsoft.EntityFrameworkCore;
using ObraPrima.Domain.Context.Entities;
using ObraPrima.Infra.Data.Context.Mappings;

namespace ObraPrima.Infra.Data.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Plan> Plans { get; set; } = null!;
    public virtual DbSet<PeriodPlan> PeriodPlans { get; set; } = null!;
    public virtual DbSet<OptionalPlan> OptionalPlans { get; set; } = null!;
    public virtual DbSet<FunctionPlan> FunctionPlans { get; set; } = null!;
    public virtual DbSet<Function> Functions { get; set; } = null!;
    public virtual DbSet<Proposal> Proposals { get; set; } = null!;
    public virtual DbSet<ProposalHistory> ProposalHistories { get; set; } = null!;
    public virtual DbSet<ProposalProduct> ProposalProducts { get; set; } = null!;
    public virtual DbSet<ProposalProductOptional> ProposalProductOptionals { get; set; } = null!;
    public virtual DbSet<Lead> Leads { get; set; } = null!;
    public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new PlanMap());
        modelBuilder.ApplyConfiguration(new PeriodPlanMap());
        modelBuilder.ApplyConfiguration(new OptionalPlanMap());
        modelBuilder.ApplyConfiguration(new FunctionPlanMap());
        modelBuilder.ApplyConfiguration(new FunctionMap());
        modelBuilder.ApplyConfiguration(new LeadMap());
        modelBuilder.ApplyConfiguration(new SupplierMap());
        modelBuilder.ApplyConfiguration(new ProposalMap());
        modelBuilder.ApplyConfiguration(new ProposalProductMap());
        modelBuilder.ApplyConfiguration(new ProposalProductOptionalMap());
        modelBuilder.ApplyConfiguration(new ProposalHistoryMap());
    }
}