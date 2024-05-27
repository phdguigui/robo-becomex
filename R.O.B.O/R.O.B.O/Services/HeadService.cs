using R.O.B.O_.Enum;
using R.O.B.O_.Model;
using R.O.B.O_.Services.Interfaces;

namespace R.O.B.O_.Services
{
    public class HeadService : IHeadService
    {
        public bool Rotate(int angle, Head head)
        {
            try
            {
                // Verify if the angle is over the limits
                if (angle <= (int)HeadRotationAngleEnum.OverNegative || angle >= (int)HeadRotationAngleEnum.OverPositive)
                {
                    return false;
                }

                // Verify if the angle is available
                if (angle == (int)head.Angle + 1 || angle == (int)head.Angle - 1 || angle == (int)head.Angle)
                {
                    // Verify if the head position is down
                    if (head.Position == HeadPositionEnum.Down)
                    {
                        return false;
                    }

                    head.Angle = (HeadRotationAngleEnum)angle;
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Incline(int position, Head head)
        {
            // Verify if the position is over the limits
            if (position <= (int)HeadPositionEnum.OverDown || position >= (int)HeadPositionEnum.OverUp)
            {
                return false;
            }

            // Verify if the angle is available
            if (position == (int)head.Position + 1 || position == (int)head.Position - 1 || position == (int)head.Position)
            {
                head.Position = (HeadPositionEnum)position;
                return true;
            }

            return false;
        }
    }
}
