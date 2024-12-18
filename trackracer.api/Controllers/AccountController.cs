using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyModel.Accounts.Registrationclass;
using trackracer.Interfaces;

namespace trackracer.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IAccountsManager _userAcc;
        public AccountController(IAccountsManager userAcc)
        {
            _userAcc = userAcc;
        }

        [HttpPost]
        public IActionResult AddUser(RegistrationModel userRegistration)
        {
            var result = _userAcc.RegistrationMethod(userRegistration);
            if (result)
            {
                return Ok(true);
            }
            return Ok(false);
        }
        [HttpGet]
        public IActionResult Login(string username, string password)
        {
            var result = _userAcc.Login(username, password);
            if (result)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost]
        public IActionResult ChangePassword(Guid UserID, string currentpassword, string newpassword)
        {
            var result = _userAcc.ChangePassword(UserID, currentpassword, newpassword);
            if (result)
            {
                return Ok(true);
            }
            return Ok(false);
        }
        [HttpPost]
        public IActionResult UpdateUser(RegistrationModel registrationModel)
        {
            var result = _userAcc.UpdateUser(registrationModel);
            if (result)
            {
                return Ok(true);
            }
            return NotFound(false);
        }
        [HttpGet]
        public IActionResult GetUser(string username)
        {
            RegistrationModel userModel = _userAcc.GetUser(username);
            return Ok(userModel);

        }
       
    }
}
