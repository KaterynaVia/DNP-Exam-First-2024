using WebApplication1.Model;

namespace WebApplication1.Data;

public class DataService:IDataService
{
    public IList<Project> Projects { get; } = new List<Project>();
    private int _nextProjectId = 1; // Auto-increment for Project Ids
    private int _nextUserStoryId = 1; // Auto-increment for UserStory Ids
    public DataService()
    {
        Projects.Add(new Project
            {
                Id = 1,
                Title ="Project 1",
                Status = "Open",
                Responsible = "Admin",
                UserStories = new List<UserStory>
                {
                    new UserStory{ Id=1,Description = "Setup Project",Estimate = "2 days"},
                    new UserStory{ Id=2,Description = "Setup Project with requirements",Estimate = "3 days"},
                }
            });
        Projects.Add(new Project
        {
            Id = 2,
            Title ="Project Beta",
            Status = "Completed",
            Responsible = "Bob",
            UserStories = new List<UserStory>
            {
                new UserStory{ Id=3,Description = "Development",Estimate = "5 days"},
                new UserStory{ Id=4,Description = "Write documentation",Estimate = "3 days"},
            }
        });
    }
    public void AddProject(Project project)
    {
        project.Id = _nextProjectId++;
        Projects.Add(project);
    }
    public void AddUserStory(int projectId, UserStory userStory)
    {
        var project = Projects.FirstOrDefault(p => p.Id == projectId);
        if (project == null) throw new ArgumentException("Project not found");

        userStory.Id = _nextUserStoryId++;
        project.UserStories.Add(userStory);
    }
    public Project GetProjectById(int id)
    {
        return Projects.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Project> GetAllProjects(string status = null, string responsible = null)
    {
        return Projects
            .Where(p => (string.IsNullOrEmpty(status) || p.Status == status) &&
                        (string.IsNullOrEmpty(responsible) || p.Responsible == responsible));
    }
}

