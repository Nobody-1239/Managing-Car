using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car_RentEntities database = new Car_RentEntities();

            Console.WriteLine("/rent => rent car");
            Console.WriteLine("/remove => remove");
            Console.WriteLine("/show => show customer and car's");
            Console.WriteLine("/exit= > exit console");
            Console.WriteLine("__________________________________");
            string resualt = Console.ReadLine();

            switch (resualt)
            {
                case "/rent":
                    Console.WriteLine("enter name - lastname - national number - place");
                    customer customer = new customer
                    {
                        name = Console.ReadLine(),
                        lastname = Console.ReadLine(),
                        nationalnumber = Console.ReadLine(),
                        place = Console.ReadLine(),
                    };
                    database.customers.Add(customer);
                    database.SaveChanges();
                    Console.WriteLine("enter car name and price");
                    car car = new car
                    {
                        carname = Console.ReadLine(),
                        price = Console.ReadLine(),
                    };
                    database.cars.Add(car);
                    database.SaveChanges();
                    Console.WriteLine("finished");
                    break;

                case "/show":
                    var item = (from a in database.customers
                                join b in database.cars on a.Id equals b.Id
                                select new
                                {
                                    a.Id,
                                    a.name,
                                    a.lastname,
                                    a.nationalnumber,
                                    a.place,
                                    b.carname,
                                    b.price,
                                });
                    foreach (var list in item)
                    {
                        Console.WriteLine($"id : {list.Id}, name : {list.name}, lastname : {list.lastname}, national number : {list.nationalnumber}, palce : {list.place}, car : {list.carname}, price : {list.price}$");
                    }
                    break;

                case "/remove":
                    Console.WriteLine("enter id");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    var resualt1 = database.customers.SingleOrDefault(n => n.Id == ID);
                    database.customers.Remove(resualt1);
                    var resualt2 = database.cars.SingleOrDefault(n => n.Id == ID);
                    database.cars.Remove(resualt2);
                    Console.WriteLine("removed successfully");
                    break;


            }
        }
    }
}
