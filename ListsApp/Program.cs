namespace ListsApp
{
    internal class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }


        }

        static void Main(string[] args)
        {
            
            // Declare a list of complex objects with initial values
            List<Product> products = new List<Product>() {
             // we can set an object property values right after creating it using this syntax -> new Object() {prop1=x...propN=xn}
             new Product {Name = "Apple", Price = 0.80 },
             new Product {Name = "Banana", Price = 1.50 },
             new Product { Name = "Corn", Price = 15 }
            
            };

            // Add items to the list
            products.Add(new Product { Name= "iPhone 17 Pro", Price= 1200 });


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Available Products: \n");
            Console.ResetColor();

            // iterate through the list
            foreach (Product product in products)
            {
                Console.WriteLine($"Product Name: {product.Name} for {product.Price} \n");
            }

            // Where returns an IEnumerable --> products.Where(p => p.Price < 1.0) we have to convert it to a list
            // This gives us a product list where the product price is less than 1 dollar
            List<Product> cheapProducts =  products.Where(p => p.Price < 1.0).ToList();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Available Products for less than 1$: \n");
            Console.ResetColor();

            // iterate through the list
            foreach (Product product in cheapProducts)
            {
                Console.WriteLine($"Product Name: {product.Name} for {product.Price} \n");
            }

            Console.ReadLine();
        }

    }
}
