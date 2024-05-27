using R.O.B.O_.Enum;
using System.Reflection.Metadata.Ecma335;

namespace R.O.B.O_.Model
{
    public class Head
    {
        private HeadRotationAngleEnum _angle = 0;
        private HeadPositionEnum _position = 0;

        public HeadRotationAngleEnum Angle { get => _angle; set => _angle = value; }
        public HeadPositionEnum Position { get => _position; set => _position = value; }

        public Head() 
        {
            _angle = 0;
            _position = 0;
        }
    }
}
