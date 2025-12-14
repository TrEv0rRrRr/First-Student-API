using eb7414u20231b475.API.Operations.Domain.Model.Aggregate;
using eb7414u20231b475.API.Operations.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace eb7414u20231b475.API.Operations.Infrastructure.Persistence.EFC.Configuration.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyOperationsConfiguration(this ModelBuilder builder)
        {
            var students = new[]
            {
                new Student(1, "Emma", "Smith", 1, 101),
                new Student(2, "Liam", "Smith", 1, 101),
                new Student(3, "Olivia", "Johnson", 1, 102),
                new Student(4, "Noah", "Johnson", 1, 102),
                new Student(5, "Ava", "Wilson", 2, 103),
                new Student(6, "James", "Wilson", 2, 103),
                new Student(7, "Sophia", "Anderson", 2, 104),
                new Student(8, "William", "Anderson", 2, 104),
                new Student(9, "Isabella", "Jackson", 3, 105),
                new Student(10, "Lucas", "Jackson", 3, 105)
            };

            builder.Entity<Student>().HasData(students);

            builder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id).IsRequired();
                entity.Property(s => s.FirstName).IsRequired();
                entity.Property(s => s.LastName).IsRequired();
                entity.Property(s => s.DistrictId).IsRequired();
                entity.Property(s => s.ParentId).IsRequired();
            });

            builder.Entity<Assignment>(entity =>
            {
                entity.HasOne<Student>().WithOne().HasForeignKey<Assignment>(a => a.StudentId).IsRequired();
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
                entity.Property(a => a.StudentId).IsRequired();
                entity.Property(a => a.BusId).IsRequired();

                // TODO: Agregar lógica de relación con el aggregate Bus
                // entity.HasOne<Bus>().WithMany().HasForeignKey(a => a.BusId).IsRequired();
            });
        }
    }
}