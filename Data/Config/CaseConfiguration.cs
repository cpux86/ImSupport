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
    public class CaseConfiguration : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {

            builder.Property(p => p.Id)
                .HasColumnOrder(0);
            builder.Property(p => p.CaseId)
                .HasColumnOrder(1);
            builder.Property(p => p.Title)
                .HasColumnOrder(2);
            //builder.Property(p => p.CreatedData)
            //    .HasDefaultValueSql("datetime('now')");
        }
    }
}
