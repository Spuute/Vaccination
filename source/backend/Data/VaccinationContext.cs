using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class VaccinationContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }
        public virtual DbSet<Vaccine> AvailableDoses { get; set; }

        public VaccinationContext(DbContextOptions<VaccinationContext> options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(v => v.Vaccination)
                .WithOne(x => x.Person)
                .HasForeignKey<Vaccination>(f => f.PersonId);
        }
    }
}