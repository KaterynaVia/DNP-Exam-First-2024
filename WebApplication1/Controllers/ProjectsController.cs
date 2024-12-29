using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Model;
namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectsController:ControllerBase
{
   
    private readonly IDataService _dataService;

    public ProjectsController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpPost]
    public IActionResult CreateProject([FromBody] Project project)
    {
        _dataService.AddProject(project);
        return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
    }

    [HttpPost("{projectId}/userstories")]
    public IActionResult AddUserStory(int projectId, [FromBody] UserStory userStory)
    {
        try
        {
            _dataService.AddUserStory(projectId, userStory);
            return Ok(userStory);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetProjectById(int id)
    {
        var project = _dataService.GetProjectById(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    [HttpGet]
    public IActionResult GetAllProjects([FromQuery] string status = null, [FromQuery] string responsible = null)
    {
        var projects = _dataService.GetAllProjects(status, responsible);
        return Ok(projects);
    }
} 
