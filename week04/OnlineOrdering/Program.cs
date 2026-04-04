using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "OR", "USA");
        Customer customer1 = new Customer("Maria Gonzalez", address1);

        List<Product> products1 = new List<Product>();
        products1.Add(new Product("Wireless Earbuds", "WE-4417", 34.95, 2));
        products1.Add(new Product("Portable Charger", "PC-8823", 22.49, 1));
        products1.Add(new Product("Screen Protector", "SP-1150", 7.99, 4));

        Order order1 = new Order(products1, customer1);

        Address address2 = new Address("27 Rue de Rivoli", "Paris", "Île-de-France", "France");
        Customer customer2 = new Customer("Takeshi Nakamura", address2);

        List<Product> products2 = new List<Product>();
        products2.Add(new Product("Standing Desk Mat", "DM-3364", 41.00, 1));
        products2.Add(new Product("Webcam HD 1080p", "WC-7790", 63.50, 1));

        Order order2 = new Order(products2, customer2);

        List<Order> orders = new List<Order>();
        orders.Add(order1);
        orders.Add(order2);

        foreach (Order order in orders)
        {
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine();
        }
    }
}
