using FluentAssertions;
using R.O.B.O_.Enum;
using R.O.B.O_.Model;
using R.O.B.O_.Services;

namespace TestProject
{
    [TestClass]
    public class HeadTest
    {
        private Head _head = new Head();
        private HeadService _headService = new HeadService();

        [TestMethod]
        public void RotateWithHeadDownSuccess()
        {
            _head.Position = HeadPositionEnum.Down;
            _headService.Rotate(1, _head).Should().Be(false);
            _head.Angle.Should().Be(HeadRotationAngleEnum.Rest);
        }

        [TestMethod]
        public void RotateWithHeadUpSuccess()
        {
            _head.Position = HeadPositionEnum.Up;
            _headService.Rotate(1, _head).Should().Be(true);
            _head.Angle.Should().Be(HeadRotationAngleEnum.Positive45Degrees);
        }

        [TestMethod]
        public void RotateTwiceWithHeadUpSuccess()
        {
            _head.Position = HeadPositionEnum.Up;
            _headService.Rotate(1, _head).Should().Be(true);
            _headService.Rotate(2, _head).Should().Be(true);
            _head.Angle.Should().Be(HeadRotationAngleEnum.Positive90Degrees);
        }

        [TestMethod]
        public void OverRotateSuccess()
        {
            _head.Position = HeadPositionEnum.Up;
            _headService.Rotate(1, _head).Should().Be(true);
            _headService.Rotate(2, _head).Should().Be(true);
            _headService.Rotate(3, _head).Should().Be(false);
            _head.Angle.Should().Be(HeadRotationAngleEnum.Positive90Degrees);
        }

        [TestMethod]
        public void RotateTwiceInOneSuccess()
        {
            _headService.Rotate(2, _head).Should().Be(false);
            _head.Angle.Should().Be(HeadRotationAngleEnum.Rest);
        }

        [TestMethod]
        public void InclineHeadUpSuccess()
        {
            _headService.Incline(1, _head).Should().Be(true);
            _head.Position.Should().Be(HeadPositionEnum.Up);
        }

        [TestMethod]
        public void InclineHeadDownSuccess()
        {
            _headService.Incline(-1, _head).Should().Be(true);
            _head.Position.Should().Be(HeadPositionEnum.Down);
        }

        [TestMethod]
        public void OverInclineHead()
        {
            _headService.Incline(2, _head).Should().Be(false);
            _head.Position.Should().Be(HeadPositionEnum.Rest);
        }
    }
}