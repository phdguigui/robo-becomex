using R.O.B.O_.Enum;
using R.O.B.O_.Model;

namespace R.O.B.O_.Responses
{
    public class ArmResponse
    {
        private ElbowResponse _elbow;
        private FistResponse _fist;
        public ElbowResponse Elbow { get => _elbow; private set => _elbow = value; }
        public FistResponse Fist { get => _fist; private set => _fist = value; }

        public ArmResponse(Arm arm)
        {
            _elbow = new ElbowResponse(arm.Elbow);
            _fist = new FistResponse(arm.Fist);
        }
    }
}
