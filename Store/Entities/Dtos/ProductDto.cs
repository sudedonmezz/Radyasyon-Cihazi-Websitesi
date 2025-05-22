using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
          public int ProductId { get; init; }
       [Required(ErrorMessage ="ProductName is required.")]
       public String? ProductName { get; init; }=String.Empty;
       public String? ProductDescription { get; init; }=String.Empty;
       public String? ProductTechnicalSpecs { get; init; } = String.Empty;  
       public String? ProductUsageAreas { get; init; } = String.Empty;
       public String? ProductDocumentsPath { get; init; } = String.Empty;
       public double? ProductWeight { get; init; } 
       public String? ImageUrl { get; set; }

       [Required(ErrorMessage ="ProductPrice is required.")]
        public decimal ProductPrice { get; init; }

       public int? CategoryId { get; init; }  
      
    }
}