using Grpc.Core;
using System.Threading.Tasks;

namespace Echo.Service.Services
{
    public class EchoService: Echoer.EchoerBase
    {
        public override Task<EchoReply> Say(SayRequest request, ServerCallContext context)
        {
            return Task.FromResult(new EchoReply
            {
                Message = $"you said: {request.Message}"
            });
        }
    }
}
