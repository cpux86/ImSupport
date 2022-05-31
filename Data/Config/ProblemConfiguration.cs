using AppCore.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> builder)
        {

            builder.Property(p => p.Id)
                .HasColumnOrder(0);
            builder.Property(p => p.Title)
                .HasColumnOrder(1);
            builder.Property(p => p.CreatedDataTime)
                .HasDefaultValueSql("datetime('now')");
        }
    }
}
