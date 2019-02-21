using OnBoardingHumanaAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OnBoardingHumanaAPI.DAL;

namespace OnBoardingHumanaAPI.Controllers
{
    [RoutePrefix("api/projects")]
    public class ProjectController : ApiController
    {

        private IProjectRepository projectRepository;

        public ProjectController()
        {
            this.projectRepository = new ProjectRepository(new OnBoardingHumanaContext());
        }

        public ProjectController(IProjectRepository userRepository)
        {
            this.projectRepository = userRepository;
        }
        

        // GET api/projects
        [Route("")]
        [HttpGet]
        public IEnumerable<Project> GetAllProjects()
        {
            return projectRepository.GetProjects();
        }

        // GET api/projects/5
        [Route("{id:int}")]
        public IHttpActionResult GetProject(int id)
        {
            var project = projectRepository.GetProjects().FirstOrDefault((p) => p.id == id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult PostProject(ProjectViewModel projectModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");           
                var project = new Project()
                {
                   ProjectID=projectModel.ProjectID,
                   ProjectDescription=projectModel.ProjectDescription
                };

            projectRepository.InsertProject(project);
            projectRepository.Save();

            return Ok();
        }
    }
}