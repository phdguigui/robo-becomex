using R.O.B.O_.Enum;
using R.O.B.O_.Model;
using R.O.B.O_.Services.Interfaces;

namespace R.O.B.O_.Services
{
    public class FistService : IFistService
    {
        public bool Rotate(int angle, Arm arm)
        {
            try
            {
                // Verify if the angle is over the limits
                if (angle <= (int)FistRotationAngleEnum.OverNegative || angle >= (int)FistRotationAngleEnum.OverPositive)
                {
                    return false;
                }

                // Verify if the angle is available
                if (angle == (int)arm.Fist.Angle + 1 || angle == (int)arm.Fist.Angle - 1 || angle == (int)arm.Fist.Angle)
                {
                    if (arm.Elbow.Position != ElbowPositionEnum.Strong)
                    {
                        return false;
                    }
                    arm.Fist.Angle = (FistRotationAngleEnum)angle;
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
