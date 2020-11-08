using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Echo.Service.Services
{
    public class EchoService: Echoer.EchoerBase
    {
        private readonly ILogger<EchoService> logger;

        public EchoService(ILogger<EchoService> logger) 
        {
            this.logger = logger;
        }

        public override Task<EchoReply> Say(SayRequest request, ServerCallContext context)
        {
            logger.LogDebug("Recieved a new message");
            return Task.FromResult(new EchoReply
            {
                Message = $"you said: {request.Message}"
            });
        }
    }
}
