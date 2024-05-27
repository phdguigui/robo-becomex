using FluentAssertions;
using R.O.B.O_.Enum;
using R.O.B.O_.Model;
using R.O.B.O_.Services;

namespace TestProject
{
    [TestClass]
    public class ElbowTest
    {
        private Elbow _elbow = new Elbow();
        private ElbowService _elbowService = new ElbowService();

        [TestMethod]
        public void ContractElbowSuccess()
        {
            _elbowService.Contract(1, _elbow).Should().Be(true);
            _elbow.Position.Should().Be(ElbowPositionEnum.Slight);
        }

        [TestMethod]
        public void ContractElbowTwiceSuccess()
        {
            _elbowService.Contract(1, _elbow).Should().Be(true);
            _elbowService.Contract(2, _elbow).Should().Be(true);
            _elbow.Position.Should().Be(ElbowPositionEnum.Contracted);
        }

        [TestMethod]
        public void ContractElbowThriceSuccess()
        {
            _elbowService.Contract(1, _elbow).Should().Be(true);
            _elbowService.Contract(2, _elbow).Should().Be(true);
            _elbowService.Contract(3, _elbow).Should().Be(true);
            _elbow.Position.Should().Be(ElbowPositionEnum.Strong);
        }

        [TestMethod]
        public void OverContractElbowSuccess()
        {
            _elbowService.Contract(1, _elbow).Should().Be(true);
            _elbowService.Contract(2, _elbow).Should().Be(true);
            _elbowService.Contract(3, _elbow).Should().Be(true);
            _elbowService.Contract(4, _elbow).Should().Be(false);
            _elbow.Position.Should().Be(ElbowPositionEnum.Strong);
        }

        [TestMethod]
        public void OverRelaxElbowSuccess()
        {
            _elbowService.Contract(-1, _elbow).Should().Be(false);
            _elbow.Position.Should().Be(ElbowPositionEnum.Rest);
        }

        [TestMethod]
        public void ContractTwiceInOne()
        {
            _elbowService.Contract(2, _elbow).Should().Be(false);
            _elbow.Position.Should().Be(ElbowPositionEnum.Rest);
        }
    }
}