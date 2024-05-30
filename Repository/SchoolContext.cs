using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repository;

public class SchoolContext : DbContext
{       
    //entities
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }
    
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=master;User Id=sa;Password=Passw1rd;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relación Uno a Uno
        // En este caso, un estudiante tiene un grado y un grado está asociado a un solo estudiante.
        // Para este tipo de relación, necesitarías tener una propiedad de navegación en ambas entidades y configurar la relación en el método OnModelCreating.
        /*
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Grade)
            .WithOne(g => g.Student)
            .HasForeignKey<Student>(s => s.GradeId);
        */

        // Relación Uno a Muchos
        // En este caso, un grado puede tener muchos estudiantes, pero un estudiante solo puede tener un grado.
        // Para este tipo de relación, necesitarías tener una propiedad de navegación en la entidad 'Grade' y una propiedad de navegación y una clave foránea en la entidad 'Student'.
        
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Grade)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.GradeId);
        

        // Relación Muchos a Muchos
        // En este caso, un estudiante puede tener muchos grados y un grado puede estar asociado a muchos estudiantes.
        // Para este tipo de relación, necesitarías tener una propiedad de navegación en ambas entidades y una tabla de unión o una colección en ambas entidades
        /*
        modelBuilder.Entity<StudentGrade>()
            .HasKey(sg => new { sg.StudentId, sg.GradeId });

        modelBuilder.Entity<StudentGrade>()
            .HasOne(sg => sg.Student)
            .WithMany(s => s.StudentGrades)
            .HasForeignKey(sg => sg.StudentId);

        modelBuilder.Entity<StudentGrade>()
            .HasOne(sg => sg.Grade)
            .WithMany(g => g.StudentGrades)
            .HasForeignKey(sg => sg.GradeId);
        */
    }
} 