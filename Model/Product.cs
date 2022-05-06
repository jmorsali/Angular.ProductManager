using Bogus;

namespace Session12.ProductManager.Model;

public record Product
{
    public static Faker<Product> FakeData { get; } =
        new Faker<Product>()
            .RuleFor(p => p.id, f => new Random().Next())
            .RuleFor(p => p.name, f => f.Name.FirstName())
            .RuleFor(p => p.price, f => f.Finance.Amount());

    public decimal price { get; set; }

    public string name { get; set; }

    public int id { get; set; }
}