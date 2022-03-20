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
    public class DepartmentConfiguraiton : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Property(d => d.Description).HasColumnType("varchar(4000)");

            builder.HasData(
                new Department { Id = 1, Name = "Yazılım", Description = "Yazılım kod geliştirme departmanı" },
                new Department { Id = 2, Name = "Proje Analiz", Description = "Proje analizi, iş analizi ve genel tasarım" },
                new Department { Id = 3, Name = "Grafik ve Arayüz", Description = "Arayüz ve görsel tasarım departmanı" },
                new Department { Id = 4, Name = "Yönetim", Description = "Yöneticiler departmanı" }

                );

        }
    }
}
