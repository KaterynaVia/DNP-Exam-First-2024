using WebApplication1.Model;
using System.Collections.Generic;

namespace WebApplication1.Data;


    public interface IDataService
    {
        IList<Project> Projects { get; }
        void AddProject(Project project);
        void AddUserStory(int projectId, UserStory userStory);
        Project GetProjectById(int id);
        IEnumerable<Project> GetAllProjects(string status = null, string responsible = null);
    }
