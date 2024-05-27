using R.O.B.O_.Enum;
using R.O.B.O_.Model;

namespace R.O.B.O_.Responses
{
    public class RobotResponse
    {
        private HeadResponse _head;
        private ArmResponse _leftArm;
        private ArmResponse _rightArm;
        public HeadResponse Head { get => _head; private set => _head = value; }
        public ArmResponse LeftArm { get => _leftArm; private set => _leftArm = value; }
        public ArmResponse RightArm { get => _rightArm; private set => _rightArm = value; }

        public RobotResponse(Robot robot)
        {
            _head = new HeadResponse(robot.Head);
            _leftArm = new ArmResponse(robot.LeftArm);
            _rightArm = new ArmResponse(robot.RightArm);
        }
    }
}
