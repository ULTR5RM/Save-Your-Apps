using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Save_Yoour_Apps.Models;
using Save_Yoour_Apps.Work;

namespace Save_Yoour_Apps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eventController : ControllerBase
    {
        [HttpGet("{app}")]
        public async Task<IActionResult> Get(string app)
        {
            if (AppsWorker.IdentityToId(app) == -1)
            {
                return BadRequest("App doesn't exists");
            }
            EventsWorker.AddEvent(EventType.GET, app);
            return Ok("Get success");
        }
        [HttpPost("{app}")]
        public async Task<IActionResult> Post(string app)
        {
            if (AppsWorker.IdentityToId(app) == -1)
            {
                return BadRequest("App doesn't exists");
            }
            EventsWorker.AddEvent(EventType.POST, app);
            return Ok("Post success");
        }
    }
}
