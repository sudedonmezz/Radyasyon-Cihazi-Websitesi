using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Product
{
      public int ProductId { get; set; }

      public String? ProductName { get; set; } = String.Empty;
      public String? ProductDescription { get; set; } = String.Empty;
      public String? ProductTechnicalSpecs { get; set; } = String.Empty;  
      public String? ProductUsageAreas { get; set; } = String.Empty;
      public String? ProductDocumentsPath { get; set; } = String.Empty;
      public double? ProductWeight { get; set; }
      public String? ImageUrl { get; set; } = String.Empty;
      public decimal ProductPrice { get; set; }

      public int? CategoryId { get; set; }  
      public Category? Category { get; set; } 

      public bool ShowCase { get; set; }
       
       public ICollection<ProductAnalysis> Analyses { get; set; } = new List<ProductAnalysis>();

}
