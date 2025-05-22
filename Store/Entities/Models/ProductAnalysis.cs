namespace Entities.Models

{
public class ProductAnalysis
{
    public int Id { get; set; }

    public int ProductId { get; set; } 
    public Product Product { get; set; }

    public string? UserEmail { get; set; } // kullanıcı analizi görebilsin diye tanımladım.

    public DateTime Timestamp { get; set; }
    public double Value { get; set; }
}

}

