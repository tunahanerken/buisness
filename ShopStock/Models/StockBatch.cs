using System.ComponentModel.DataAnnotations;

namespace ShopStock.Models;

public class StockBatch
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string BatchCode { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    public DateTime ReceivedAt { get; set; } = DateTime.UtcNow;

    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
