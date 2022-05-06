namespace Session12.ProductManager.Model;

public static class OnlineStoreDataSeed
{
    public static void SeedData(OnlineStoreContext context)
    {
        if (context.Products.FirstOrDefault()==null)
        {
           context.Products.AddRange( Product.FakeData.Generate(new Random().Next(1,8)));
           context.Persons.AddRange( Person.FakeData.Generate(new Random().Next(1,7)));
           context.SaveChanges();
        }
    }
}