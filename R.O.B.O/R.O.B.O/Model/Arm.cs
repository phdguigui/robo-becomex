namespace R.O.B.O_.Model
{
    public class Arm
    {
        private Elbow _elbow;
        private Fist _fist;
        public Elbow Elbow { get => _elbow; set => _elbow = value; }
        public Fist Fist { get => _fist; set => _fist = value; }

        public Arm()
        {
            _elbow = new Elbow();
            _fist = new Fist();
        }
    }
}
