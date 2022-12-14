using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace ConsoleAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".Net Core 2.1");
            var connection = new HubConnectionBuilder()
               .WithUrl("https://localhost:44375/chat")
               .Build();
            connection.On<string, string>("ReceiveMessage", (name, message) => Console.WriteLine($"{name}  {message}"));
            connection.StartAsync().Wait();

            Console.Write("Enter your name: ");
            var nameUser = Console.ReadLine();

            while (true)
            {
                var msg = Console.ReadLine();
                connection.InvokeAsync("Send", nameUser, msg);
            }

        }
    }
}
