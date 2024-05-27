using Microsoft.AspNetCore.Mvc;
using R.O.B.O_.Responses;
using R.O.B.O_.Services;

namespace R.O.B.O_.Controller
{
    [ApiController]
    [Route("api/elbow")]
    public class ElbowController : ControllerBase
    {
        private readonly ElbowService _elbowService = new ElbowService();

        [HttpPost]
        [Route("left/contract")]
        public ActionResult<bool> ContractLeftElbow([FromQuery] int position)
        {
            return Ok(_elbowService.Contract(position, RobotInstance.Instance.LeftArm.Elbow));
        }

        [HttpPost]
        [Route("right/contract")]
        public ActionResult<bool> ContractRightElbow([FromQuery] int position)
        {
            return Ok(_elbowService.Contract(position, RobotInstance.Instance.RightArm.Elbow));
        }
    }
}
