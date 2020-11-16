using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Google.Protobuf.WellKnownTypes;

namespace WhatTimeIsItNow.Service.Services
{
    public class TimeService: Timer.TimerBase
    {
        private readonly ILogger<TimeService> logger;

        public TimeService(ILogger<TimeService> logger) 
        {
            this.logger = logger;
        }

        public override Task<TimerReply> Say(SayRequest request, ServerCallContext context)
        {
            logger.LogDebug("Recieved a new message");
            return Task.FromResult(new TimerReply
            {
                Time= Timestamp.FromDateTime(DateTime.UtcNow)
            });
        }

    }
}
