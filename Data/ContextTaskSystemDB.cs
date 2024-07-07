using Microsoft.EntityFrameworkCore;
using minhaprimeiraapi.Model;

namespace minhaprimeiraapi.Data
{
    public class ContextTaskSystemDB : DbContext
    {
            public ContextTaskSystemDB(DbContextOptions<ContextTaskSystemDB> options) : base(options)
            {

            }

            public DbSet<UserModel> User { get; set;}
            public DbSet<ServiceModel> Services { get; set;}
            public DbSet<UserProfileModel> UserProfile { get; set;}
            public DbSet<AppointmentsModel> Appointments { get; set;}
            public DbSet<AppointmentServicesModel> AppointmentServices { get; set;}
            public DbSet<EmailsModel> Emails { get; set;}
            public DbSet<ProfessionalModel> Professional { get; set;}
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ServiceMap());
            modelBuilder.ApplyConfiguration(new UserProfileMap());
            modelBuilder.ApplyConfiguration(new ProfessionalsMap());
            modelBuilder.ApplyConfiguration(new EmailsMap());
            modelBuilder.ApplyConfiguration(new AppointmentsMap());
            modelBuilder.ApplyConfiguration(new AppointmentServicesMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
