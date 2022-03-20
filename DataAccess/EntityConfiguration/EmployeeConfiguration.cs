using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired().HasColumnType("varchar(100)");
            builder.Property(e => e.LastName).IsRequired().HasColumnType("varchar(100)");

            builder.HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId); 
            
            builder.Property(e => e.Title).HasColumnType("varchar(100)");
            builder.Property(e => e.HireDate).HasColumnType("date");
            builder.Property(e => e.LeaveDate).HasColumnType("date");

            builder.HasData(
            new Employee() { Id = 1, FirstName = "Fuat", LastName = "Aydın", DepartmentId = 1, Title = "Yazılım geliştirici", HireDate = DateTime.ParseExact("01.01.2012", "dd.MM.yyyy", null), LeaveDate = null },
            new Employee() { Id = 2, FirstName = "Murat", LastName = "Odabaş", DepartmentId = 1, Title = "Yazılım geliştirici", HireDate = DateTime.ParseExact("05.10.2015", "dd.MM.yyyy", null), LeaveDate = null },
            new Employee() { Id = 3, FirstName = "Berna", LastName = "Demir", DepartmentId = 1, Title = "Yazılım geliştirici", HireDate = DateTime.ParseExact("01.05.2014", "dd.MM.yyyy", null), LeaveDate = DateTime.ParseExact("10.09.2019", "dd.MM.yyyy", null) },
            new Employee() { Id = 4, FirstName = "Ali", LastName = "Turan", DepartmentId = 2, Title = "İş Analisti", HireDate = DateTime.ParseExact("16.08.2014", "dd.MM.yyyy", null), LeaveDate = null },
            new Employee() { Id = 5, FirstName = "Berker", LastName = "Aksoy", DepartmentId = 2, Title = "İş analisti", HireDate = DateTime.ParseExact("16.08.2014", "dd.MM.yyyy", null), LeaveDate = DateTime.ParseExact("05.09.2015", "dd.MM.yyyy", null) },
            new Employee() { Id = 6, FirstName = "Ayşe", LastName = "Yıldırım", DepartmentId = 3, Title = "Grafik tasarımcı", HireDate = DateTime.ParseExact("20.02.2018", "dd.MM.yyyy", null), LeaveDate = null },
            new Employee() { Id = 7, FirstName = "Seda", LastName = "Kaya", DepartmentId = 4, Title = " Proje Yöneticisi", HireDate = DateTime.ParseExact("01.07.2010", "dd.MM.yyyy", null), LeaveDate = null },
            new Employee() { Id = 8, FirstName = "Batuhan", LastName = "Aydın", DepartmentId = 4, Title = " Ar-ge yöneticisi", HireDate = DateTime.ParseExact("01.08.2011", "dd.MM.yyyy", null), LeaveDate = null }
                );

        }
    }
}
