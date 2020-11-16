﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using WhatTimeIsItNow.Client;

namespace Echo.Client
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Say something");
            var userInput = "damn it works";
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GetGrpcChannel();
            var client =  new Echoer.EchoerClient(channel);
            var reply = await client.SayAsync(
                new SayRequest { Message = userInput });
            Console.WriteLine("Received reply: " + reply.Message);
            
            var clientTimer =  new Timer.TimerClient(channel);
            var replyForTime= await clientTimer.SayAsync(
                new WhatTimeIsItNow.Client.SayRequest { Message = userInput });
            Console.WriteLine("Get the current time because i have watch:"+ replyForTime);
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static GrpcChannel GetGrpcChannel()
        {
            return GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
            {
                HttpHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback =
                        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                }
            });
        }
    }
}