// Berényi Bence 11.D
// Asztali alkalmazás fejlesztések óra
// 2024.11.26

// Sok linq mágia volt használva a kódban, és classokat is használtam de így jobban readable

namespace Shop {
  class Program {
    static List<Product> warehouse = new List<Product>();
    static List<CartItem> cart = new List<CartItem>();

    static void Main(string[] args) {
      warehouse.Add(new Product("Alma", 1.0, 10));
      warehouse.Add(new Product("Banán", 0.5, 20));
      warehouse.Add(new Product("Narancs", 0.8, 15));

      while (true) {
        Console.WriteLine("1. Display warehouse products");
        Console.WriteLine("2. Add product to cart");
        Console.WriteLine("3. Display cart contents");
        Console.WriteLine("4. Remove product from cart");
        Console.WriteLine("5. Empty cart");
        Console.WriteLine("6. Simulate purchase");
        Console.WriteLine("7. Display most expensive product");
        Console.WriteLine("8. Display cheapest product");
        Console.WriteLine("9. Display cart statistics");
        Console.WriteLine("10. Check warehouse stock");
        Console.WriteLine("11. Display cart total value");
        Console.WriteLine("12. Add new product to warehouse");
        Console.WriteLine("13. Sort warehouse products by price");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an option: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice) {
          case 1:
            DisplayWarehouseProducts();
            break;
          case 2:
            AddProductToCart();
            break;
          case 3:
            DisplayCartContents();
            break;
          case 4:
            RemoveProductFromCart();
            break;
          case 5:
            EmptyCart();
            break;
          case 6:
            SimulatePurchase();
            break;
          case 7:
            DisplayMostExpensiveProduct();
            break;
          case 8:
            DisplayCheapestProduct();
            break;
          case 9:
            DisplayCartStatistics();
            break;
          case 10:
            CheckWarehouseStock();
            break;
          case 11:
            DisplayCartTotalValue();
            break;
          case 12:
            AddNewProductToWarehouse();
            break;
          case 13:
            SortWarehouseProductsByPrice();
            break;
          case 0:
            return;
          default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
        }
      }
    }

    static void DisplayWarehouseProducts() {
      Console.WriteLine("Warehouse Products:");
      foreach (var product in warehouse) {
        Console.WriteLine($"{product.Name} - ${product.Price} - {product.Quantity} in stock");
      }
    }

    static void AddProductToCart() {
      Console.Write("Enter product name: ");
      string name = Console.ReadLine();
      Console.Write("Enter quantity: ");
      int quantity = int.Parse(Console.ReadLine());

      var product = warehouse.FirstOrDefault(p => p.Name == name);
      if (product != null && product.Quantity >= quantity) {
        cart.Add(new CartItem(name, quantity));
        product.Quantity -= quantity;
        Console.WriteLine("Product added to cart.");
      } else {
        Console.WriteLine("Product not available or insufficient stock.");
      }
    }

    static void DisplayCartContents() {
      Console.WriteLine("Cart Contents:");
      foreach (var item in cart) {
        Console.WriteLine($"{item.Name} - {item.Quantity}");
      }
    }

    static void RemoveProductFromCart() {
      Console.Write("Enter product name: ");
      string name = Console.ReadLine();

      var item = cart.FirstOrDefault(i => i.Name == name);
      if (item != null) {
        var product = warehouse.FirstOrDefault(p => p.Name == name);
        if (product != null) {
          product.Quantity += item.Quantity;
        }
        cart.Remove(item);
        Console.WriteLine("Product removed from cart.");
      } else {
        Console.WriteLine("Product not found in cart.");
      }
    }

    static void EmptyCart() {
      foreach (var item in cart) {
        var product = warehouse.FirstOrDefault(p => p.Name == item.Name);
        if (product != null) {
          product.Quantity += item.Quantity;
        }
      }
      cart.Clear();
      Console.WriteLine("Cart emptied.");
    }

    static void SimulatePurchase() {
      double total = 0;
      Console.WriteLine("Purchase Details:");
      foreach (var item in cart) {
        var product = warehouse.FirstOrDefault(p => p.Name == item.Name);
        if (product != null) {
          total += item.Quantity * product.Price;
          Console.WriteLine($"{item.Name} - {item.Quantity} x ${product.Price} = ${item.Quantity * product.Price}");
        }
      }
      Console.WriteLine($"Total: ${total}");
      cart.Clear();
    }

    static void DisplayMostExpensiveProduct() {
      var product = warehouse.OrderByDescending(p => p.Price).FirstOrDefault();
      if (product != null) {
        Console.WriteLine($"Most expensive product: {product.Name} - ${product.Price}");
      } else {
        Console.WriteLine("No products in warehouse.");
      }
    }

    static void DisplayCheapestProduct() {
      var product = warehouse.OrderBy(p => p.Price).FirstOrDefault();
      if (product != null) {
        Console.WriteLine($"Cheapest product: {product.Name} - ${product.Price}");
      } else {
        Console.WriteLine("No products in warehouse.");
      }
    }

    static void DisplayCartStatistics() {
      int totalItems = cart.Sum(i => i.Quantity);
      int uniqueItems = cart.Count;
      Console.WriteLine($"Cart contains {totalItems} items of {uniqueItems} different types.");
    }

    static void CheckWarehouseStock() {
      foreach (var product in warehouse) {
        if (product.Quantity < 5) {
          Console.WriteLine($"Warning: {product.Name} stock is below 5.");
        }
      }
    }

    static void DisplayCartTotalValue() {
      double total = 0;
      foreach (var item in cart) {
        var product = warehouse.FirstOrDefault(p => p.Name == item.Name);
        if (product != null) {
          total += item.Quantity * product.Price;
        }
      }
      Console.WriteLine($"Total cart value: ${total}");
    }

    static void AddNewProductToWarehouse() {
      if (warehouse.Count >= 10) {
        Console.WriteLine("Warehouse is full.");
        return;
      }

      Console.Write("Enter product name: ");
      string name = Console.ReadLine();
      Console.Write("Enter product price: ");
      double price = double.Parse(Console.ReadLine());
      Console.Write("Enter product quantity: ");
      int quantity = int.Parse(Console.ReadLine());

      warehouse.Add(new Product(name, price, quantity));
      Console.WriteLine("Product added to warehouse.");
    }

    static void SortWarehouseProductsByPrice() {
      warehouse = warehouse.OrderBy(p => p.Price).ToList();
      Console.WriteLine("Warehouse products sorted by price.");
    }
  }

  class Product {
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, double price, int quantity) {
      Name = name;
      Price = price;
      Quantity = quantity;
    }
  }

  class CartItem {
    public string Name { get; set; }
    public int Quantity { get; set; }

    public CartItem(string name, int quantity) {
      Name = name;
      Quantity = quantity;
    }
  }
}