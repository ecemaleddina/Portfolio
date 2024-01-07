using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class WorkCategoryConfiguration : IEntityTypeConfiguration<WorkCategory>
    {
        public void Configure(EntityTypeBuilder<WorkCategory> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);
            builder.HasIndex(x => new { x.Name, x.Deleted }).IsUnique().HasDatabaseName("idx_Name_Deleted_Category");
        }
    }
}
