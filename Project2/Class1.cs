using Alachisoft.NCache.Client;
using System;
using System.Collections.Generic;
using CacheItem = Alachisoft.NCache.Client.CacheItem;

namespace Project2
{
    class Class1
    {
        private static Customer[] customers = new Customer[10000];
        private static IDictionary<string, CacheItem> items = new Dictionary<string, CacheItem>();
        private static ICache cache;

        static public void Main()
        {
            string cacheName = "FirstCache";
            cache = CacheManager.GetCache(cacheName);

            while (true)
            {
                Console.WriteLine("1: Populate Default Cache Data");
                Console.WriteLine("2: Add Customer");
                Console.WriteLine("3: Get Data");
                Console.WriteLine("4: Update Data");
                Console.WriteLine("5: Remove Data");
                Console.WriteLine("6: Clear Cache Data");
                Console.WriteLine("7: Check the existance of Customer");
                string x = Console.ReadLine();

                if (x == "1")
                {
                    cache.Clear();
                    try
                    {
                        AddData();
                    }
                    catch
                    {
                        Console.WriteLine("Data Already Exists !");
                    }
                }

                if (x == "2")
                {
                   AddCustomer();
                }
                if (x == "3")
                {
                    GetCustomer();
                }
                if (x == "4")
                {
                    Insert();
                }
                if (x == "5")
                {
                    Remove();
                }
                if (x == "6")
                {
                    cache.Clear();
                }
                if (x == "7")
                {
                    Console.WriteLine("Enter CustomerID: ");
                    string id = Console.ReadLine();
                    bool status = cache.Contains(id);
                    Console.WriteLine(status);
                    Console.WriteLine();
                }
            }

        }

        public static void PopulateCache()
        {
            CacheItem[] cacheItem1 = new CacheItem[10000];

            int i = 0;
            while (i < 10000)
            {
                customers[i] = new Customer("", "", "", "");
                customers[i].CustomerId = $"Customer {i}";
                customers[i].CustomerName = $"Ali";
                customers[i].CustomerPhone = $"012345{i}";
                customers[i].CustomerCity = "London";
                cacheItem1[i] = new CacheItem(customers[i]);
                i = i + 1;
            }
            i = 0;

            while (i < 10000)
            {
                items.Add($"Customer{i}", cacheItem1[i]);
                i = i + 1;
            }
        }


        private static void AddData()
        {
            PopulateCache();
            cache.AddBulk(items);
            Console.WriteLine("Items added!");
        }          

        private static void GetCustomer()
        {
            try
            {
                Console.WriteLine("Enter CustomerId to Search: ");
                string key = Console.ReadLine();
                Customer cust = cache.Get<Customer>(key);
               // Console.WriteLine(cache.GetCacheItem(key));
                Console.WriteLine();
                Console.WriteLine("Customer Details: ");
                if (cust == null)
                {
                    Console.WriteLine("CUSTOMER HAS BEEN REMOVED ");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Id: " + cust.CustomerId);
                    Console.WriteLine("Name: " + cust.CustomerName);
                    Console.WriteLine("Phone: " + cust.CustomerPhone);
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void Insert()
        {
            Console.WriteLine("Enter CustomerId to update data: ");
            string id = Console.ReadLine();
            Customer customer = new Customer();
            customer.CustomerId = id;
            customer.CustomerPhone = "03454733774";
            customer.CustomerName = "The name has been changed ";
            cache.Insert(id, customer);
        }

        private static void Remove()
        {
            Console.WriteLine("Enter CustomerId to Remove: "); 
            string id = Console.ReadLine();
            cache.Remove(id);
        }

        private static void AddCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter CustomerId: ");
            string id = Console.ReadLine();
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter City: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            customer.CustomerId = id;
            customer.CustomerName = name;
            customer.CustomerCity = city;
            customer.CustomerPhone = phoneNumber;

            cache.Add(id, customer);
        }

    }
}
