using FluentAssertions;
using R.O.B.O_.Enum;
using R.O.B.O_.Model;
using R.O.B.O_.Responses;
using R.O.B.O_.Services;

namespace TestProject
{
    [TestClass]
    public class RobotTest
    {
        private Robot _robot = new Robot(new Head(), new Arm(), new Arm());
        private RobotService _robotService = new RobotService();

        [TestMethod]
        public void RotateWithHeadDownSuccess()
        {
            RobotInstance.Instance.Head.Position = HeadPositionEnum.Up;
            RobotInstance.Instance.RightArm.Elbow.Position = ElbowPositionEnum.Contracted;
            RobotInstance.Instance.LeftArm.Fist.Angle = FistRotationAngleEnum.Positive180Degrees;

            _robotService.ResetRobot().Should().Be("Robô reiniciado com sucesso");
            RobotInstance.Instance.Head.Position.Should().Be(HeadPositionEnum.Rest);
            RobotInstance.Instance.RightArm.Elbow.Position.Should().Be(ElbowPositionEnum.Rest);
            RobotInstance.Instance.LeftArm.Fist.Angle.Should().Be(FistRotationAngleEnum.Rest);
        }

        [TestMethod]
        public void GetArmsSuccess()
        {
            _robotService.GetArms(_robot).Count.Should().Be(2);
        }

        [TestMethod]
        public void GetHeadSuccess()
        {
            _robotService.GetHead(_robot).Head.Position.Should().Be(HeadPositionEnum.Rest);
            _robotService.GetHead(_robot).Head.Angle.Should().Be(HeadRotationAngleEnum.Rest);
        }
    }
}