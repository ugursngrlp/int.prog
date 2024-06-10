using Microsoft.EntityFrameworkCore;

namespace Int.Prog.Final.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciDetay;Integrated Security=true;TrustServerCertificate=true");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Student entity configuration
            modelBuilder.Entity<Student>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Student>().Property(s => s.Name)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.Age)
                .HasColumnType("int")
                .IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.Surname)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();

            // Course entity configuration
            modelBuilder.Entity<Course>().ToTable("tblCourses");
            modelBuilder.Entity<Course>().Property(c => c.CourseName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            // StudentCourse entity configuration
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
