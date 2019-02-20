using OnBoardingHumanaAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OnBoardingHumanaAPI.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private User[] users = new User[]
        {
        };

        // GET api/users
        [Route("")]
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        // GET api/users/5
        [Route("{id:int}")]
        public IHttpActionResult GetUser(int id)
        {
            var product = users.FirstOrDefault((p) => p.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult PostUser(UserViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new OnBoardingHumanaContext())
            {
                ctx.Users.Add(new User()
                {
                    CognizantID = user.CognizantID,
                    ProjectDescription = user.ProjectDescription,
                    HumanaID = user.HumanaID,
                    ProjectID = user.ProjectID
                });

                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}