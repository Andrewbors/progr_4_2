using System;
using System.Diagnostics;

namespace pr2
{
    public class Currency
    {
        protected String Name;
        protected double ExRate;

        public Currency() { }

        public Currency(String Name)
        {
            this.Name = Name;
        }

        public Currency(String Name, double ExRate)
        {
            this.Name = Name;
            this.ExRate = ExRate;
        }

        public String getName() { return Name; }
        public double getExRate() { return ExRate; }

        public void setName(String name) { Name = name; }
        public void setExRate(double exRate) { ExRate = exRate; }

    }
    public class Product
    {
        protected String Name;
        protected Currency Cost;
        protected double Price;
        protected int Quantity;
        protected int Weight;
        protected String Producer;

        public Product() { }

        public Product(String Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }

        public Product(String Name, Currency Cost, double Price, int Quantity, int Weight, String Producer)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.Price = Price;
            this.Quantity = Quantity;
            this.Weight = Weight;
            this.Producer = Producer;
        }

        public String getName() { return Name; }
        public Currency getCost() { return Cost; }
        public double getPrice() { return Price; }
        public int getQuantity() { return Quantity; }
        public int getWeight() { return Weight; }
        public String getProducer() { return Producer; }

        public void setName(String name) { Name = name; }
        public void setCost(Currency cost) { Cost = cost; }
        public void setPrice(double price) { Price = price; }
        public void setQuantity(int quantity) { Quantity = quantity; }
        public void setWeight(int weight) { Weight = weight; }
        public void setProducer(String producer) { Producer = producer; }

        public int GetPriceInUAH()
        {
            return (int)(Price * Cost.getExRate());
        }

        public int GetTotalPriceInUAH()
        {
            return (int)(Price * Cost.getExRate() * Quantity);
        }

        public int GetTotalWeight()
        {
            return Weight * Quantity;
        }
    }
    
    public class Program
    {
        public static void Main(String[] args)
        {
            Product[]products = ReadProductsArray();
            PrintProducts(products);
        }

        private static int n = 5;

        public static Product[] ReadProductsArray()
        {
            Product[]products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Name: ");
                String name = Console.ReadLine();

                Console.WriteLine("Currency: ");
                String currencyName = Console.ReadLine();

                Console.WriteLine("Exchange rate: ");
                double exRate = Convert.ToDouble(Console.ReadLine());

                Currency cost = new Currency(currencyName, exRate);

                Console.WriteLine("Price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Weight: ");
                int weight = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Producer: ");
                String producer = Console.ReadLine();

                products[i] = new Product(name, cost, price, quantity, weight, producer);
            }

            return products;
        }

        public static void PrintProduct(Product product)
        {
            Console.WriteLine($"Name: {product.getName()}");
            Console.WriteLine($"Currency: {product.getCost().getName()}");
            Console.WriteLine($"Exchange rate: {product.getCost().getExRate()}");
            Console.WriteLine($"Quantity: {product.getQuantity()}");
            Console.WriteLine($"Weight: {product.getWeight()}");
            Console.WriteLine($"Producer: {product.getProducer()}");
        }

        public static void PrintProducts(Product[]products)
        {
            foreach (Product p in products)
            {
                PrintProduct(p);
                Console.WriteLine("");
            }
        }

        public static Product[] GetProductsInfo(Product[]products)
        {
            Product min = products[0];
            Product max = products[0];

            for (int i = 0; i < products.Length; i++)
            {
                if (min.getPrice() > products[i].getPrice())
                {
                    min = products[i];
                }

                if (max.getPrice() < products[i].getPrice())
                {
                    max = products[i];
                }
            }

            Product[]result = { min, max };
            return result;
        }

        public static Product[] GetProductsByPrice(Product[]products)
        {
            for (int i = 1; i < products.Length; i++)
            {
                for (int j = 0; j < products.Length - 1; j++)
                {
                    if (products[j].getPrice() < products[j + 1].getPrice())
                    {
                        Product temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }

            return products;
        }

        public static Product[] GetProductsByCount(Product[]products)
        {
            for (int i = 1; i < products.Length; i++)
            {
                for (int j = 0; j < products.Length - 1; j++)
                {
                    if (products[j].getQuantity() < products[j + 1].getQuantity())
                    {
                        Product temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }

            return products;
        }
    }
}
