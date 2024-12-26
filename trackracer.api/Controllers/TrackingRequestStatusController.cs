using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trackracer.api.Interfaces;
using trackracer.Models.Accounts;

namespace trackracer.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrackingRequestStatusController : ControllerBase
    {

        private readonly ITrackingRequestStatusManager _trackingManager;

        public TrackingRequestStatusController(ITrackingRequestStatusManager trackingManager)
        {
            _trackingManager = trackingManager;
        }

        [HttpPost]
        public IActionResult SaveRequest(TrackingRequestStatusModel request)
        {
            var result = _trackingManager.SaveRequest(request);
            if (result)
            {
                return Ok(true);
            }
            return BadRequest(false);
        }

        [HttpGet]
        public IActionResult GetAllRequestStatuses()
        {
            var requests = _trackingManager.GetAllRequestStatuses();
            return Ok(requests);
        }

        [HttpGet]
        public IActionResult GetRequestStatusBySenderID(Guid senderId)
        {
            var request = _trackingManager.GetRequestStatusBySenderID(senderId);
            if (request != null)
            {
                return Ok(request);
            }
            return NotFound(null);
        }

        [HttpGet]
        public IActionResult GetTrackingRequestByReceiverID(Guid receiverId)
        {
            var request = _trackingManager.GetTrackingRequestByReceiverID(receiverId);
            if (request != null)
            {
                return Ok(request);
            }
            return NotFound(null);
        }



    }
}
