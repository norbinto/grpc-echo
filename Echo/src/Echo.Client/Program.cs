using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace Echo.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Say something");
            var userInput = Console.ReadLine();
            
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            
            var client =  new Echoer.EchoerClient(channel);
            var reply = await client.SayAsync(
                new SayRequest { Message = userInput });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}