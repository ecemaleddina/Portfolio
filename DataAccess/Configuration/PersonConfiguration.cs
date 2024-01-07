using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x=>x.LastName).HasMaxLength(50);
            builder.Property(x => x.WebSite).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x=>x.Address).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(50);

        }
    }
}
