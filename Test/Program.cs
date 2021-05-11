using System;
using System.Linq;
using System.Reflection.Metadata;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new SimpleTraderDbContextFactory());

            var user = userService.Create(new User()
            {
                Email = "Test@gmail.com",
                Username = "Test"
            }).Result;

            Console.WriteLine(user.Username);

            var countUser = userService.GetAll().Result.Count();

            Console.WriteLine(countUser);

            Console.WriteLine(userService.Get(1).Result.Username);

            Console.WriteLine(userService.Update(2, new User(){Username = "TestUser"}).Result.Username);
        }
    }
}
