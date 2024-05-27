using R.O.B.O_.Enum;

namespace R.O.B.O_.Model
{
    public class Fist
    {
        private FistRotationAngleEnum _angle = 0;
        public FistRotationAngleEnum Angle { get => _angle; set => _angle = value; }

        public Fist()
        {
            _angle = 0;
        }
    }
}
