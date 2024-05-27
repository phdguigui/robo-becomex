namespace R.O.B.O_.Model
{
    public class Robot
    {
        public Head Head { get; set; }
        public Arm RightArm { get; set; }
        public Arm LeftArm { get; set; }

        public Robot(Head head, Arm rightArm, Arm leftArm)
        {
            Head = head;
            RightArm = rightArm;
            LeftArm = leftArm;
        }
    }
}
