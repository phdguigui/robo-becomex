using R.O.B.O_.Model;
using R.O.B.O_.Responses;
using R.O.B.O_.Services.Interfaces;

namespace R.O.B.O_.Services
{
    public class ArmService : IArmService
    {
        public ElbowResponse GetElbow(Arm arm)
        {
            return new ElbowResponse(arm.Elbow);
        }

        public FistResponse GetFist(Arm arm)
        {
            return new FistResponse(arm.Fist);
        }
    }
}
