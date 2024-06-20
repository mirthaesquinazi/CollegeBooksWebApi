using LinqToDB.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LinqToDB.Tools.DataProvider.SqlServer.Schemas.ServiceBrokerSchema;

namespace CollegeBooks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    //[Authorize]
    public class ApiBaseController : ControllerBase
    {
        protected ApiBaseController()
        {
        }
    }
}
