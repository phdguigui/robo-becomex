using Microsoft.AspNetCore.Mvc;
using R.O.B.O_.Responses;
using R.O.B.O_.Services;

namespace R.O.B.O_.Controller
{
    [ApiController]
    [Route("api/robot")]
    public class RobotController : ControllerBase
    {
        private readonly RobotService _robotService = new RobotService();

        [HttpPost]
        [Route("reset")]
        public ActionResult<string> ResetRobot()
        {
            return Ok(_robotService.ResetRobot());
        }

        [HttpGet]
        [Route("arms")]
        public ActionResult<List<ArmResponse>> GetRobotArms()
        {
            return Ok(_robotService.GetArms(RobotInstance.Instance));
        }

        [HttpGet]
        [Route("arm/right")]
        public ActionResult<ArmResponse> GetRightArm()
        {
            return Ok(_robotService.GetArm(RobotInstance.Instance.RightArm));
        }

        [HttpGet]
        [Route("arm/left")]
        public ActionResult<ArmResponse> GetLeftArm()
        {
            return Ok(_robotService.GetArm(RobotInstance.Instance.LeftArm));
        }

        [HttpGet]
        [Route("head")]
        public ActionResult<HeadResponse> GetRightFist()
        {
            return Ok(_robotService.GetHead(RobotInstance.Instance));
        }
    }
}
