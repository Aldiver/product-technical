using add_cart_exam.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace add_cart_exam.Server;

[ApiController]
[Route("api")]
public class ProductController : ControllerBase{
    
    DataContext _context;

    public ProductController(DataContext context){
        _context = context;
    }

    [HttpGet("GetProducts")]
    public IActionResult GetProducts(){
        return Ok(_context.Products.ToList());
    }

    [HttpPost("AddProduct")]

    public IActionResult AddProduct(int id, string name, int cost, int quantity)
    {
        try
        {
            var product = new Products
            {
                ProductId = id,
                ProductName = name,
                Cost = cost,
                Quantity = quantity,
                Amount = cost * quantity
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return new JsonResult(true);
        }
        catch (Exception e)
        {
            return new JsonResult(false);
        }
    }

    //Remove product
    [HttpPost("RemoveProduct/{id}")]
    public IActionResult RemoveProduct(int id)
    {
        try
        {
            var product = _context.Products.Where(r => r.ProductId.Equals(id)).FirstOrDefault();

            if (product == null)
                throw new Exception("no movie found");

            _context.Products.Remove(product);
            _context.SaveChanges();

            return new JsonResult(true);
        }
        catch (Exception e)
        {
            return new JsonResult(false);
        }
    }
    [HttpGet("FindProduct/{id}")]
    public IActionResult FindProduct(int id)
    {
        try
        {
            var product = _context.Products.Where(r => r.ProductId.Equals(id)).FirstOrDefault();

            if (product == null)
                throw new Exception("no movie found");

            return new JsonResult(product);
        }
        catch (Exception e)
        {
            return new JsonResult(false);
        }
    }
}