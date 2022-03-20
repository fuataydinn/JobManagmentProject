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
    public class MainConfiguration : IEntityTypeConfiguration<MainTask>
    {
        public void Configure(EntityTypeBuilder<MainTask> builder)
        {
            builder.HasKey(task => task.Id);
            builder.Property(task => task.Name).IsRequired().IsUnicode(false).HasMaxLength(200);
            builder.Property(task => task.Description);
        }
    }
}
