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
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(500);
            builder.Property(x=>x.Description).HasMaxLength(2000);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);
        }
    }
}
