using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductAnalysisConfig : IEntityTypeConfiguration<ProductAnalysis>
    {
              public void Configure(EntityTypeBuilder<ProductAnalysis> builder)
              {
                     builder.HasKey(pa => pa.Id);

                     builder.Property(pa => pa.Timestamp)
                            .IsRequired();

                     builder.Property(pa => pa.Value)
                            .IsRequired();

                     builder.HasOne(pa => pa.Product)
                            .WithMany(p => p.Analyses)
                            .HasForeignKey(pa => pa.ProductId)
                            .OnDelete(DeleteBehavior.Cascade);

                     builder.Property(pa => pa.UserEmail)
                            .HasMaxLength(100);
                   builder.ToTable("ProductAnalyses"); 

        }
    }
}
