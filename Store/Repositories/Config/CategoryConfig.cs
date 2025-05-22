using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repositories.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c=>c.CategoryId);
            builder.Property(c=>c.CategoryName).IsRequired();


            builder.HasData(
 
            new Category { CategoryId = 1, CategoryName = "Elektronik Dozimetre" },
            new Category { CategoryId = 2, CategoryName = "Pasif Dozimetre" },
            new Category { CategoryId = 3, CategoryName = "Survey Metre" },
            new Category { CategoryId = 4, CategoryName = "Yüzey Kontaminasyon Ölçer" },
            new Category { CategoryId = 5, CategoryName = "Alan Monitörü" },
            new Category { CategoryId = 6, CategoryName = "Baca Dedektör" }
               
            );
        }
    }
}