namespace PerTak.Api.Domain.Models;

public class Work : BaseEntity
{
    public string? WorkerName { get; set; }
    public DateTime WorkerTime { get; set; }
    public string? JobName { get; set; }
    public string? Comments { get; set; }
    
    public Guid DepartmenId { get; set; }
    
    public virtual Departmen Departmen { get; set; }
    
}