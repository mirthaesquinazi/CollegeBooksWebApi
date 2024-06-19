using CollegeBooks.Logic.Services;

namespace CollegeBooks.Api.Controllers
{
    public class UsersController : ApiBaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userServices)
        {
            _userService = userServices;
        }

      
    }
}
