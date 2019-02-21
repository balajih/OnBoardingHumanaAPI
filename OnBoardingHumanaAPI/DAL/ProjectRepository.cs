using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OnBoardingHumanaAPI.Models;

namespace OnBoardingHumanaAPI.DAL
{
    public class ProjectRepository : IProjectRepository, IDisposable
    {
        private OnBoardingHumanaContext context;

        public ProjectRepository(OnBoardingHumanaContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project> GetProjects()
        {
            return context.Projects.ToList();
        }

        public Project GetProjectByID(int id)
        {
            return context.Projects.Find(id);
        }

        public void InsertProject(Project project)
        {
            context.Projects.Add(project);
        }

        public void DeleteProject(int projectId)
        {
            Project project = context.Projects.Find(projectId);
            context.Projects.Remove(project);
        }

        public void UpdateProject(Project project)
        {
            context.Entry(project).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}