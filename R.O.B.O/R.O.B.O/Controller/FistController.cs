using Microsoft.AspNetCore.Mvc;
using R.O.B.O_.Responses;
using R.O.B.O_.Services;

namespace R.O.B.O_.Controller
{
    [ApiController]
    [Route("api/fist")]
    public class FistController : ControllerBase
    {
        private readonly FistService _fistService = new FistService();

        [HttpPost]
        [Route("left/rotate")]
        public ActionResult<bool> RotateLeftFist([FromQuery] int angle)
        {
            return Ok(_fistService.Rotate(angle, RobotInstance.Instance.LeftArm));
        }

        [HttpPost]
        [Route("right/rotate")]
        public ActionResult<bool> RotateRightFist([FromQuery] int angle)
        {
            return Ok(_fistService.Rotate(angle, RobotInstance.Instance.RightArm));
        }
    }
}