using R.O.B.O_.Enum;
using R.O.B.O_.Model;
using R.O.B.O_.Services.Interfaces;

namespace R.O.B.O_.Services
{
    public class ElbowService : IElbowService
    {
        public bool Contract(int position, Elbow elbow)
        {
            try
            {
                // Verify if the position is over the limits
                if (position <= (int)ElbowPositionEnum.OverRest || position >= (int)ElbowPositionEnum.OverStrong)
                {
                    return false;
                }

                // Verify if the angle is available
                if (position == (int)elbow.Position + 1 || position == (int)elbow.Position -1 || position == (int)elbow.Position)
                {
                    elbow.Position = (ElbowPositionEnum)position;
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
