using Microsoft.AspNetCore.Mvc;
using R.O.B.O_.Model;

namespace R.O.B.O_.Services.Interfaces
{
    public interface IHeadService
    {
        bool Rotate (int angle, Head head);
        bool Incline(int position, Head head);
    }
}
