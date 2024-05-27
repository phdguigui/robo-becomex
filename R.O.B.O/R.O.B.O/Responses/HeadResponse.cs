using R.O.B.O_.Enum;
using R.O.B.O_.Model;

namespace R.O.B.O_.Responses
{
    public class HeadResponse
    {
        private Head _head;
        private string _headPositionDescription;
        private string _headRotationAngleDescription;
        public Head Head { get => _head; private set => _head = value; }
        public string HeadPositionDescription { get => _headPositionDescription; private set => _headPositionDescription = value; }
        public string HeadRotationAngleDescription { get => _headRotationAngleDescription; private set => _headRotationAngleDescription = value; }

        public HeadResponse(Head head)
        {
            _head = head;
            _headPositionDescription = ConstructPositionDescription();
            _headRotationAngleDescription = ConstructRotationAngleDescription();
        }

        public HeadResponse()
        {
        }

        private string ConstructPositionDescription()
        {
            return _head.Position switch
            {
                HeadPositionEnum.OverUp => "Além dos limites para cima",
                HeadPositionEnum.Up => "Para Cima",
                HeadPositionEnum.Rest => "Em Repouso",
                HeadPositionEnum.Down => "Para Baixo",
                HeadPositionEnum.OverDown => "Além dos limites para baixo",
                _ => throw new NotImplementedException()
            };
        }
        private string ConstructRotationAngleDescription()
        {
            return _head.Angle switch
            {
                HeadRotationAngleEnum.OverNegative => "Além dos limites de rotação negativa",
                HeadRotationAngleEnum.Negative90Degrees => "Rotação -90°",
                HeadRotationAngleEnum.Negative45Degrees => "Rotação -45°",
                HeadRotationAngleEnum.Rest => "Em Repouso",
                HeadRotationAngleEnum.Positive45Degrees => "Rotação 45°",
                HeadRotationAngleEnum.Positive90Degrees => "Rotação 90°",
                HeadRotationAngleEnum.OverPositive => "Além dos limites de rotação positiva",
                _ => throw new NotImplementedException()
            };
        }
    }
}
