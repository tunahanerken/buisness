using System.ComponentModel.DataAnnotations;

namespace ShopStock.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [StringLength(100)]
    public string? Sku { get; set; }

    [Range(0, int.MaxValue)]
    public int WarningStockLevel { get; set; }

    [Range(0, int.MaxValue)]
    public int CrisisStockLevel { get; set; }

    public ICollection<StockBatch> StockBatches { get; set; } = new List<StockBatch>();
}
