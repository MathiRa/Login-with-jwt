using ALUXION.Domain;
using ALUXION.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ALUXION.Repositories.Implementations
{

    public class ALUXIONContext : DbContext
    {

        private readonly ALUXIONSettings _settings;

        public ALUXIONContext(IOptions<ALUXIONSettings> settings)
        {
                _settings = settings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.ConnectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            #region User

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.PhoneNumber).IsRequired(false);
                entity.Property(e => e.Provider).HasConversion<string>();
            });

            #endregion

            #region Seed

            modelBuilder.Entity<Role>()

                   .HasData(
                       new Role
                       {
                           Id = 1,
                           RoleType = RoleType.Admin
                       },
                       new Role
                       {
                           Id = 2,
                           RoleType = RoleType.User
                       }
                    );

            #endregion

 


        }


    }

}
