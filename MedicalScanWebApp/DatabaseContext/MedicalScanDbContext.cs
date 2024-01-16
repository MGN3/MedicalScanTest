using MedicalScanWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalScanWebApp.DatabaseContext {

	public class MedicalScanDbContext : DbContext {
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Specialty> Specialties { get; set; }
		public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }

		public MedicalScanDbContext(DbContextOptions<MedicalScanDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {

			////   n to n relationship   ////
			modelBuilder.Entity<DoctorSpecialty>()
					   .HasKey(ds => new { ds.DoctorId, ds.SpecialtyId });

			modelBuilder.Entity<DoctorSpecialty>()
				.HasOne(ds => ds.Doctor)
				.WithMany(d => d.DoctorSpecialties)
				.HasForeignKey(ds => ds.DoctorId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<DoctorSpecialty>()
				.HasOne(ds => ds.Specialty)
				.WithMany(s => s.DoctorSpecialties)
				.HasForeignKey(ds => ds.SpecialtyId)
				.OnDelete(DeleteBehavior.Cascade);
			////   n to n relationship    ////


			//// Constraints:

			// Doctor constraints
			modelBuilder.Entity<Doctor>()
				.Property(d => d.Name)
				.IsRequired()
				.HasMaxLength(100);

			// Specialty table constraints
			modelBuilder.Entity<Specialty>()
				.Property(s => s.Name)
				.IsRequired()
				.HasMaxLength(50);
		}
	}
}