using R.O.B.O_.Model;
using R.O.B.O_.Responses;

namespace R.O.B.O_.Services.Interfaces
{
    public interface IArmService
    {
        ElbowResponse GetElbow (Arm arm);
        FistResponse GetFist (Arm arm);
    }
}
