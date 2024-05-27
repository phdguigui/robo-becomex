using FluentAssertions;
using R.O.B.O_.Enum;
using R.O.B.O_.Model;
using R.O.B.O_.Services;

namespace TestProject
{
    [TestClass]
    public class ArmTest
    {
        private Arm _arm = new Arm();
        private ArmService _armService = new ArmService();

        [TestMethod]
        public void GetElbowSuccess()
        {
            _armService.GetElbow(_arm).ElbowPositionDescription.Should().Be("Em Repouso");
        }

        [TestMethod]
        public void GetFistSuccess()
        {
            _armService.GetFist(_arm).FistRotationAngleDescription.Should().Be("Em Repouso");
        }
    }
}