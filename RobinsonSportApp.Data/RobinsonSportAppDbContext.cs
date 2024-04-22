using Microsoft.EntityFrameworkCore;
using RobinsonSportApp.Data.Entities;

namespace RobinsonSportApp.Data;

public class RobinsonSportAppDbContext(DbContextOptions<RobinsonSportAppDbContext> options) : DbContext(options)
{
    public DbSet<Association> Associations => Set<Association>();
    public DbSet<ContactPerson> Contacts => Set<ContactPerson>();
    public DbSet<AssociationContact> AssociationContacts => Set<AssociationContact>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Association>(entity =>
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

        modelBuilder.Entity<ContactPerson>(entity =>
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

        modelBuilder.Entity<AssociationContact>(entity =>
        {
            entity.HasKey(ac => new { ac.AssociationId, ac.ContactPersonId });

            entity.HasOne(ac => ac.Association)
                  .WithMany(a => a.AssociationContacts)
                  .HasForeignKey(ac => ac.AssociationId);

            entity.HasOne(ac => ac.ContactPerson)
                  .WithMany(c => c.AssociationContacts)
                  .HasForeignKey(ac => ac.ContactPersonId);
        });

        base.OnModelCreating(modelBuilder);
    }
}
