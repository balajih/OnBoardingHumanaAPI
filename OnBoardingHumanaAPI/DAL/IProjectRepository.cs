using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnBoardingHumanaAPI.Models;

namespace OnBoardingHumanaAPI.DAL
{
    public interface IProjectRepository : IDisposable
    {
        IEnumerable<Project> GetProjects();
        Project GetProjectByID(int id);
        void InsertProject(Project project);
        void DeleteProject(int projectID);
        void UpdateProject(Project project);
        void Save();
    }
}