using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ComITProject.Dal.Model;
using ComITProject.Dal.Model.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Policy;


namespace ComITProject.Dal.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<DosageUnit> Dosages { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientDiagnosis> PatientDiagnoses { get; set; }
        public DbSet<PrescribedMedication> PrescribedMedications { get;set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Staff> Staffs { get; set;}
        public DbSet<StaffSpecialty> StaffSpecialties { get;set; }
        public DbSet<Timeslot> Timeslots { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientDiagnosis>().HasKey(pd => new { pd.PatientId, pd.DiagnosisId});
            modelBuilder.Entity<StaffSpecialty>().HasKey(ss => new { ss.StaffId, ss.SpecialtyId});

            //adding ON DELETE SET NULL to 1 out of the 2 foreign keys to avoid the 2nd cascading error 
            //both my Staff and Patient entities has a UserID as a foreign key.
            //Ultimately, if a User is deleted along with his UserID, there will be 2 cascade that can affect these tables, one is through the StaffID and the Staff entity,
            //the other is through the PatientId and Patient entity. By setting one of these cascade to be NULL ON DELETE, it is ok

            modelBuilder.Entity<Input>()
            .HasOne<Staff>(i => i.Staff)
            .WithMany(s => s.Inputs)
            .HasForeignKey(i => i.StaffId)
            .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Note>()
                .HasOne<Staff>(i => i.Staff)
                .WithMany(s => s.Notes)
                .HasForeignKey(i => i.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<PatientDiagnosis>()
                .HasOne<Staff>(i => i.Staff)
                .WithMany(s => s.PatientDiagnoses)
                .HasForeignKey(i => i.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<PrescribedMedication>()
                .HasOne<Staff>(i => i.Staff)
                .WithMany(s => s.PrescribedMedications)
                .HasForeignKey(i => i.PrescribedByStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
          
            
        }
    }
}