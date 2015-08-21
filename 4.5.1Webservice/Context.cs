namespace _4._5._1Webservice
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
            //  base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Club1)
                .HasForeignKey(e => e.Club);

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Student1)
                .HasForeignKey(e => e.Student);

            modelBuilder.Entity<Team>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.Team);
        }
    }
}
