using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopStock.Data;
using ShopStock.Models;

namespace ShopStock.Controllers;

public class ProductsController : Controller
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _context.Products
            .Include(p => p.StockBatches)
            .ToListAsync();
        return View(products);
    }

    public IActionResult Create()
    {
        return View(new ProductCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var product = new Product
        {
            Name = model.Name,
            Sku = model.Sku,
            WarningStockLevel = model.WarningStockLevel,
            CrisisStockLevel = model.CrisisStockLevel,
            StockBatches =
            {
                new StockBatch
                {
                    BatchCode = model.BatchCode,
                    Quantity = model.Quantity,
                    ReceivedAt = model.ReceivedAt ?? DateTime.UtcNow
                }
            }
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
