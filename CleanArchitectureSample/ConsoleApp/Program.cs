using System;
using ConsoleApp.User;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp {
    class Program {
        static void Main(string[] args) {
            Startup.Run();
            var serviceCollection = Startup.ServiceCollection;
            var userCreateSubject = new UserCreateSubject();
            serviceCollection.AddSingleton(userCreateSubject);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var view = new ConsoleView(userCreateSubject);

            Console.WriteLine("=======================================");
            Console.WriteLine("Welcome to sample of clean architecture");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine("Enter the name of the new user.");
            Console.WriteLine("username:");
            Console.Write(">");
            var username = Console.ReadLine();
            var controller = serviceProvider.GetService<UserController>();
            controller.CreateUser(username);

            Console.WriteLine("press any key to exit.");
            Console.ReadKey();
        }
    }
}
