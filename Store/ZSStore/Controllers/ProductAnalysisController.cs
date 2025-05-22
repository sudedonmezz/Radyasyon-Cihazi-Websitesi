using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using System.Text;
using Repositories;

namespace ZSStore.Controllers
{
    [Authorize]
    public class ProductAnalysisController : Controller
    {
        private readonly RepositoryContext _context;

        public ProductAnalysisController(RepositoryContext context)
        {
            _context = context;
        }

        
        public IActionResult MyProducts()
        {
            var email = User.Identity?.Name;

            var orders = _context.Orders
                .Where(o => o.Email == email)
                .Include(o => o.Lines)
                    .ThenInclude(l => l.Product)
                .ToList();

            var products = orders
                .SelectMany(o => o.Lines.Select(l => l.Product))
                .Distinct()
                .ToList();

            return View(products);
        }

        [HttpPost]
        [Authorize]
        public IActionResult StartAnalysis(int productId)
        {
            var email = User.Identity?.Name;
            var random = new Random();

            
            var oldAnalyses = _context.productAnalyses
                .Where(p => p.ProductId == productId && p.UserEmail == email);
            _context.productAnalyses.RemoveRange(oldAnalyses);

            
            var newAnalyses = new List<ProductAnalysis>();
            for (int i = 0; i < 15; i++)
            {
                newAnalyses.Add(new ProductAnalysis
                {
                    ProductId = productId,
                    UserEmail = email,
                    Timestamp = DateTime.Now.AddMinutes(-i * 5),
                    Value = Math.Round(random.NextDouble() * 100, 2)
                });
            }

            _context.productAnalyses.AddRange(newAnalyses);
            _context.SaveChanges();

            return RedirectToAction("DownloadCsv", new { productId });
        }


        
        public IActionResult DownloadCsv(int productId)
        {
            var email = User.Identity?.Name;

            var data = _context.productAnalyses
                .Where(p => p.ProductId == productId && p.UserEmail == email)
                .OrderBy(p => p.Timestamp)
                .ToList();

            var csv = new StringBuilder();
            csv.AppendLine("Timestamp,Value");

            foreach (var row in data)
            {
                csv.AppendLine($"{row.Timestamp},{row.Value}");
            }

            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", "analysis.csv");
        }
        

        [Authorize]
public IActionResult AnalysisChart(int productId)
{
    var email = User.Identity?.Name;

    var data = _context.productAnalyses
        .Include(p => p.Product)
        .Where(p => p.ProductId == productId && p.UserEmail == email)
        .OrderBy(p => p.Timestamp)
        .ToList();

    return View(data);
}

    }
}
