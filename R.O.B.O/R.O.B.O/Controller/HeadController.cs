using Microsoft.AspNetCore.Mvc;
using R.O.B.O_.Responses;
using R.O.B.O_.Services;

namespace R.O.B.O_.Controller
{
    [ApiController]
    [Route("api/head")]
    public class HeadController : ControllerBase
    {
        private readonly HeadService _headService = new HeadService();

        [HttpPost]
        [Route("rotate")]
        public ActionResult<bool> Rotate ([FromQuery] int angle)
        {
            return Ok(_headService.Rotate(angle, RobotInstance.Instance.Head));
        }

        [HttpPost]
        [Route("incline")]
        public ActionResult<bool> Incline ([FromQuery] int position)
        {
            return Ok(_headService.Incline(position, RobotInstance.Instance.Head));
        }
    }
}
