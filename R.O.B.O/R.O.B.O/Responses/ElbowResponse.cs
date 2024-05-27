using R.O.B.O_.Enum;
using R.O.B.O_.Model;

namespace R.O.B.O_.Responses
{
    public class ElbowResponse
    {
        private Elbow _elbow;
        private string _elbowPositionDescription;
        public Elbow Elbow { get => _elbow; private set => _elbow = value; }
        public string ElbowPositionDescription { get => _elbowPositionDescription; private set => _elbowPositionDescription = value; }

        public ElbowResponse(Elbow elbow)
        {
            _elbow = elbow;
            _elbowPositionDescription = ConstructDescription();
        }

        private string ConstructDescription ()
        {
            return _elbow.Position switch
            {
                ElbowPositionEnum.OverRest => "Além dos limites de repouso",
                ElbowPositionEnum.Rest => "Em Repouso",
                ElbowPositionEnum.Slight => "Levemente Contraído",
                ElbowPositionEnum.Contracted => "Contraído",
                ElbowPositionEnum.Strong => "Fortemente Contraído",
                ElbowPositionEnum.OverStrong => "Além dos limites da contração",
                _ => throw new NotImplementedException()
            };
        }
    }
}
