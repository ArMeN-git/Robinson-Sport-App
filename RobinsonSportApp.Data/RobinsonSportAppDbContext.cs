using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RobinsonSportApp.Data.Entities;
using RobinsonSportApp.Data.Entities.Identity;
namespace RobinsonSportApp.Data;

public class RobinsonSportAppDbContext(DbContextOptions<RobinsonSportAppDbContext> options) : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options)
{
    public DbSet<Association> Associations => Set<Association>();
    public DbSet<ContactPerson> Contacts => Set<ContactPerson>();
    public DbSet<AssociationContact> AssociationContacts => Set<AssociationContact>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    public DbSet<Event> Events => Set<Event>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().ToTable("Users");
        builder.Entity<Role>().ToTable("Roles");

        builder.Entity<Association>(entity =>
        {
            entity.Property(e => e.Name)
                  .HasMaxLength(64);

            entity.Property(e => e.PresidentFirstName)
                  .HasMaxLength(32);

            entity.Property(e => e.PresidentLastName)
                  .HasMaxLength(32);

            entity.Property(e => e.Address)
                  .HasMaxLength(64);

            entity.Property(e => e.PhoneNumbers)
                  .HasMaxLength(128);

            entity.Property(e => e.Emails)
                  .HasMaxLength(128);

            entity.Property(e => e.WebsiteUrl)
                  .HasMaxLength(128);
        });

        builder.Entity<ContactPerson>(entity =>
        {
            entity.Property(e => e.FirstName)
                  .HasMaxLength(32);

            entity.Property(e => e.LastName)
                  .HasMaxLength(32);

            entity.Property(e => e.PhoneNumber)
                  .HasMaxLength(16);

            entity.Property(e => e.Email)
                  .HasMaxLength(32);
        });

        builder.Entity<AssociationContact>(entity =>
        {
            entity.HasKey(ac => new { ac.AssociationId, ac.ContactPersonId });

            entity.HasOne(ac => ac.Association)
                  .WithMany(a => a.AssociationContacts)
                  .HasForeignKey(ac => ac.AssociationId);

            entity.HasOne(ac => ac.ContactPerson)
                  .WithMany(c => c.AssociationContacts)
                  .HasForeignKey(ac => ac.ContactPersonId);
        });

        builder.Entity<Subscription>(entity =>
        {
            entity.Property(e => e.Email)
                  .HasMaxLength(32);

            entity.Property(p => p.CreatedDate)
                  .HasDefaultValueSql("getUtcDate()");
        });

        builder.Entity<Event>(entity =>
        {
            entity.Property(p => p.CreatedDate)
                  .HasDefaultValueSql("getUtcDate()");

            entity.Property(p => p.Opponent1)
                  .HasMaxLength(64);

            entity.Property(p => p.Opponent2)
                  .HasMaxLength(64);

            entity.Property(p => p.Opponent1Logo)
                  .HasMaxLength(256);

            entity.Property(p => p.Opponent2Logo)
                  .HasMaxLength(265);

            entity.Property(p => p.Place)
                  .HasMaxLength(128);
        });

        builder.Entity<User>(entity =>
        {
            entity.HasMany(u => u.Roles)
                  .WithMany(r => r.Users)
                  .UsingEntity<UserRole>(
                    ur => ur.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId),
                    ur => ur.HasOne(ur => ur.User).WithMany().HasForeignKey(ur => ur.UserId));

            entity.HasMany<UserClaim>()
                  .WithOne()
                  .HasForeignKey(uc => uc.UserId).IsRequired();

            entity.HasMany(u => u.UserLogins)
                  .WithOne(c => c.User)
                  .HasForeignKey(u => u.UserId)
                  .IsRequired();

            entity.HasMany<UserToken>()
                  .WithOne()
                  .HasForeignKey(ut => ut.UserId);
        });

        builder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRoles");

            entity.HasKey(e => new { e.RoleId, e.UserId });
        });

        builder.Entity<UserToken>(entity =>
        {
            entity.ToTable("UserTokens");

            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
        });

        builder.Entity<RoleClaim>(entity =>
        {
            entity.ToTable("RoleClaims");
        });

        builder.Entity<UserClaim>(entity =>
        {
            entity.ToTable("UserClaims");
        });

        builder.Entity<UserLogin>(entity =>
        {
            entity.ToTable("UserLogins");

            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        });
    }
}
