using System.ComponentModel.DataAnnotations;

namespace ShopStock.Models;

public class ProductCreateViewModel
{
    [Required]
    [Display(Name = "Ürün adı")]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "SKU / Barkod")]
    [StringLength(100)]
    public string? Sku { get; set; }

    [Required]
    [Display(Name = "Parti kodu")]
    [StringLength(100)]
    public string BatchCode { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Stok miktarı")]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    [Display(Name = "Uyarı stok adedi")]
    [Range(0, int.MaxValue)]
    public int WarningStockLevel { get; set; }

    [Required]
    [Display(Name = "Kriz stok adedi")]
    [Range(0, int.MaxValue)]
    public int CrisisStockLevel { get; set; }

    [Display(Name = "Geliş tarihi")]
    public DateTime? ReceivedAt { get; set; }
}
