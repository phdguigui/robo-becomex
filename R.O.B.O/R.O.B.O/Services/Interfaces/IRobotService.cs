using R.O.B.O_.Model;
using R.O.B.O_.Responses;

namespace R.O.B.O_.Services.Interfaces
{
    public interface IRobotService
    {
        public string ResetRobot();
        public List<ArmResponse> GetArms(Robot robot);
        public ArmResponse GetArm(Arm arm);
        public HeadResponse GetHead(Robot robot);
        public RobotResponse GetRobot(Robot robot);
    }
}
