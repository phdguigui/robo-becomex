using R.O.B.O_.Enum;
using R.O.B.O_.Model;

namespace R.O.B.O_.Responses
{
    public class FistResponse
    {
        private Fist _fist;
        private string _fistRotationAngleDescription;
        public Fist Fist { get => _fist; private set => _fist = value; }
        public string FistRotationAngleDescription { get => _fistRotationAngleDescription; private set => _fistRotationAngleDescription = value; }

        public FistResponse(Fist fist)
        {
            _fist = fist;
            _fistRotationAngleDescription = ConstructDescription();
        }

        private string ConstructDescription()
        {
            return _fist.Angle switch
            {
                FistRotationAngleEnum.OverNegative => "Além dos limites da rotação negativa",
                FistRotationAngleEnum.Negative90Degrees => "Rotação para -90°",
                FistRotationAngleEnum.Negative45Degrees => "Rotação para -45°",
                FistRotationAngleEnum.Rest => "Em Repouso",
                FistRotationAngleEnum.Positive45Degrees => "Rotação para 45°",
                FistRotationAngleEnum.Positive90Degrees => "Rotação para 90°",
                FistRotationAngleEnum.Positive135Degrees => "Rotação para 135°",
                FistRotationAngleEnum.Positive180Degrees => "Rotação para 180°",
                FistRotationAngleEnum.OverPositive => "Além dos limites da rotação positiva",
                _ => throw new NotImplementedException()
            };
        }
    }
}
