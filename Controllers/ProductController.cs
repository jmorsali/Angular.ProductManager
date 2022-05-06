using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly OnlineStoreContext _productContext;

    public ProductController(OnlineStoreContext productContext)
    {
        _productContext = productContext;
    }


    [HttpGet]
    [Route("Products")]
    public IEnumerable<Product> GetProduct()
    {
        var ret = _productContext.Products.ToList();
        return ret;
    }


    [HttpPost]
    [Route("UpdateProduct")]
    public Product? UpdateProduct(Product product)
    {
        _productContext.Products.Update(product);
        _productContext.SaveChanges();

        return _productContext.Products.FirstOrDefault(x => x.id == product.id);
    }


    [HttpPost]
    [Route("AddProduct")]
    public Product? AddProduct(Product product)
    {
        _productContext.Products.Add(product);
        _productContext.SaveChanges();

        return product;
    }
}
