using R.O.B.O_.Model;
using R.O.B.O_.Responses;
using R.O.B.O_.Services.Interfaces;

namespace R.O.B.O_.Services
{
    public class RobotService : IRobotService
    {
        public string ResetRobot()
        {
            RobotInstance.Instance = new Robot(new Head(), new Arm(), new Arm());
            return "Robô reiniciado com sucesso";
        }

        public List<ArmResponse> GetArms (Robot robot)
        {
            List<ArmResponse> arm = new List<ArmResponse>();

            arm.Add(new ArmResponse(robot.LeftArm));
            arm.Add(new ArmResponse(robot.RightArm));

            return arm;
        }

        public ArmResponse GetArm (Arm arm)
        {
            return new ArmResponse(arm);
        }

        public HeadResponse GetHead (Robot robot)
        {
            return new HeadResponse(robot.Head);
        }

        public RobotResponse GetRobot(Robot robot)
        {
            return new RobotResponse(robot);
        }
    }
}
