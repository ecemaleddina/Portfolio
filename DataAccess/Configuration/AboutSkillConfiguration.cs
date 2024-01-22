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
    public class AboutSkillConfiguration: IEntityTypeConfiguration<AboutSkill>
    {
        public void Configure(EntityTypeBuilder<AboutSkill> builder)
        {
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);
            builder.HasIndex(x => new { x.SkillId, x.Deleted }).HasDatabaseName("idx_AboutSkill_SkillId_Deleted");
        }
    }
}
