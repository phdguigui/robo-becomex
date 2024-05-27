using FluentAssertions;
using R.O.B.O_.Enum;
using R.O.B.O_.Model;
using R.O.B.O_.Services;
using R.O.B.O_.Services.Interfaces;

namespace TestProject
{
    [TestClass]
    public class FistTest
    {
        private Arm _arm = new Arm();
        private FistService _fistService = new FistService();

        [TestMethod]
        public void RotateWithoutStrongContractSuccess()
        {
            _fistService.Rotate(1, _arm).Should().Be(false);
            _arm.Fist.Angle.Should().Be(FistRotationAngleEnum.Rest);
        }

        [TestMethod]
        public void RotateFistSuccess()
        {
            _arm.Elbow.Position = ElbowPositionEnum.Strong;
            _fistService.Rotate(1, _arm).Should().Be(true);
            _arm.Fist.Angle.Should().Be(FistRotationAngleEnum.Positive45Degrees);
        }

        [TestMethod]
        public void RotateFistTwiceSuccess()
        {
            _arm.Elbow.Position = ElbowPositionEnum.Strong;
            _fistService.Rotate(1, _arm).Should().Be(true);
            _fistService.Rotate(2, _arm).Should().Be(true);
            _arm.Fist.Angle.Should().Be(FistRotationAngleEnum.Positive90Degrees);
        }

        [TestMethod]
        public void RotateFistThriceSuccess()
        {
            _arm.Elbow.Position = ElbowPositionEnum.Strong;
            _fistService.Rotate(1, _arm).Should().Be(true);
            _fistService.Rotate(2, _arm).Should().Be(true);
            _fistService.Rotate(3, _arm).Should().Be(true);
            _arm.Fist.Angle.Should().Be(FistRotationAngleEnum.Positive135Degrees);
        }

        [TestMethod]
        public void RotateFistFourTimesSuccess()
        {
            _arm.Elbow.Position = ElbowPositionEnum.Strong;
            _fistService.Rotate(1, _arm).Should().Be(true);
            _fistService.Rotate(2, _arm).Should().Be(true);
            _fistService.Rotate(3, _arm).Should().Be(true);
            _fistService.Rotate(4, _arm).Should().Be(true);
            _arm.Fist.Angle.Should().Be(FistRotationAngleEnum.Positive180Degrees);
        }

        [TestMethod]
        public void OverRotateFistSuccess()
        {
            _arm.Elbow.Position = ElbowPositionEnum.Strong;
            _fistService.Rotate(1, _arm).Should().Be(true);
            _fistService.Rotate(2, _arm).Should().Be(true);
            _fistService.Rotate(3, _arm).Should().Be(true);
            _fistService.Rotate(4, _arm).Should().Be(true);
            _fistService.Rotate(5, _arm).Should().Be(false);
            _arm.Fist.Angle.Should().Be(FistRotationAngleEnum.Positive180Degrees);
        }
    }
}