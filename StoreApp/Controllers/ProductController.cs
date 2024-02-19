using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories;

namespace StoreApp.Controllers;

public class ProductController : Controller
{
    private readonly RepositoryContext _context;

    public ProductController(RepositoryContext context)
    {
        _context = context;
    }

    // GET
    public IActionResult Index()
    {

        var model = _context.Products.ToList();
        return View(model);
    }

    public IActionResult Get(int id)
    {
        Product product = _context.Products.FirstOrDefault(p => p.ProductId.Equals((id)));
        return View(product);
    }
}