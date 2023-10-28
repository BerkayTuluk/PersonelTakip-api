namespace PerTak.Api.Domain.Models;

public class Departmen : BaseEntity
{
    public string DepartmenName { get; set; }
    
    public Guid WorkId { get; set; }
    
    public virtual ICollection<Work> works { get; set; }    
}