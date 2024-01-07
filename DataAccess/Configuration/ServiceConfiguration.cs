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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.IconName).HasMaxLength(500);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);
        }
    }
}
