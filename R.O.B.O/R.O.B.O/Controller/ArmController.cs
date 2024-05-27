using Microsoft.AspNetCore.Mvc;
using R.O.B.O_.Model;
using R.O.B.O_.Responses;
using R.O.B.O_.Services;

namespace R.O.B.O_.Controller
{
    [ApiController]
    [Route("api/arm")]
    public class ArmController : ControllerBase
    {
        private readonly ArmService _armService = new ArmService();

        [HttpGet]
        [Route("left/elbow")]
        public ActionResult<ElbowResponse> GetLeftElbow()
        {
            return Ok(_armService.GetElbow(RobotInstance.Instance.LeftArm));
        }

        [HttpGet]
        [Route("right/elbow")]
        public ActionResult<ElbowResponse> GetRightElbow()
        {
            return Ok(_armService.GetElbow(RobotInstance.Instance.RightArm));
        }

        [HttpGet]
        [Route("left/fist")]
        public ActionResult<FistResponse> GetLeftFist()
        {
            return Ok(_armService.GetFist(RobotInstance.Instance.LeftArm));
        }

        [HttpGet]
        [Route("right/fist")]
        public ActionResult<FistResponse> GetRightFist()
        {
            return Ok(_armService.GetFist(RobotInstance.Instance.RightArm));
        }
    }
}
