using R.O.B.O_.Model;

namespace R.O.B.O_.Services
{
    public static class RobotInstance
    {
        private static Robot _instance = new Robot(new Head(), new Arm(), new Arm());

        public static Robot Instance { get => _instance; set => _instance = value; }
    }

}
