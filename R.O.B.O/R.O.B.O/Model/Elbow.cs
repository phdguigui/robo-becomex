using R.O.B.O_.Enum;

namespace R.O.B.O_.Model
{
    public class Elbow
    {
        private ElbowPositionEnum _position = 0;
        public ElbowPositionEnum Position { get => _position; set => _position = value; }
        public Elbow() 
        {
            _position = 0;
        }
    }
}
