using OnBoardingHumanaAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OnBoardingHumanaAPI.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private User[] users = new User[]
        {
        };

        [Route("GetUser")]
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public IHttpActionResult GetUser(int id)
        {
            var product = users.FirstOrDefault((p) => p.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}