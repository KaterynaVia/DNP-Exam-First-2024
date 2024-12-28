using WebApplication1.Model;

namespace WebApplication1.Data;

public class DataService:IDataService
{
    public IList<Project> Projects { get; } = new List<Project>();
}