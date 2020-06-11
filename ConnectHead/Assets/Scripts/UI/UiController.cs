using System.Threading.Tasks;
using Actors;
using Onorno.ProtoActor;
using Proto;

namespace UI
{
    public class UiController : MonoBehaviourWithLoggerWithProtoActor
    {


        public override string ActorName => nameof(ActorsName.UiManager);
        public override Task ReceiveAsync(IContext context)
        {
            switch (context.Message)
            {
                default:
                    Logger.WarnFormat("Received unknown message: {0}", context.Message.ToString());
                    break;
            }

            return Actor.Done;
        }
    }
}
