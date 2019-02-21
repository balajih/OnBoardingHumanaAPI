using OnBoardingHumanaAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OnBoardingHumanaAPI.DAL;

namespace OnBoardingHumanaAPI.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {

        private IUserRepository userRepository;

        public UserController()
        {
            this.userRepository = new UserRepository(new OnBoardingHumanaContext());
        }

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        

        // GET api/users
        [Route("")]
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetUsers();
        }

        // GET api/users/5
        [Route("{id:int}")]
        public IHttpActionResult GetUser(int id)
        {
            var product = userRepository.GetUsers().FirstOrDefault((p) => p.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult PostUser(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");           
                var user = new User()
                {
                    CognizantID = userModel.CognizantID,
                    ProjectDescription = userModel.ProjectDescription,
                    HumanaID = userModel.HumanaID,
                    ProjectID = userModel.ProjectID
                };
            
            userRepository.InsertUser(user);
            userRepository.Save();

            return Ok();
        }
    }
}