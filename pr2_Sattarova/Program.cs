using System.Collections.Generic;

List<Product> products = new List<Product>();
products.Add(new Product("Мишка", 100, 25, Category.toys));
products.Add(new Product("Картошка", 9999, 1, Category.food));
products.Add(new Product("Кукла", 200, 0, Category.toys));
products.Add(new Product("Iphone", 1000, 2, Category.electro));
products.Add(new Product("Пицца", 5, 100, Category.food));

public enum Category
{
    food = 0,
    toys = 1,
    electro = 2
}

public class Product
{
    static public int ids = 0;
    public int id { get; }
    
    public string Name { get; set; }
    public decimal price { get; set; }
    public int quantity { get; set; }
    public bool InStock => quantity > 0;
    public Category Category { get; set; }

    public Product(string n, decimal p, int q, Category category)
    {
        if (string.IsNullOrWhiteSpace(n)) throw new ArgumentException("Название товара не должно быть пустым");
        if (p <= 0) throw new ArgumentException("Цена должна быть положительной");
        if (q < 0) throw new ArgumentException("Количество не может быть отрицательным");
        ids += 1;
        id += ids;
        Name = n.Trim();
        price = p;
        quantity = q;
        Category = category;
    }
    public void Vivod() { Console.WriteLine($"ID: {id} | Название: {Name} | Цена: {price:F2} | Количество {quantity} В наличии: {(InStock ? "Да" : "Нет")} | Категория: {Category} "); }
}
