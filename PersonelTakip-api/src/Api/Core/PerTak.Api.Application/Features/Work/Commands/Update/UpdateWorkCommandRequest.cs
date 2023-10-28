using MediatR;

namespace PerTak.Api.Application.Features.Work.Commands.Update;

public class UpdateWorkCommandRequest : IRequest<Guid>
{
    public Guid Id { get; set; }  
    public string WorkerName { get; set; }
    public DateTime WorkerTime { get; set; }
    public string JobName { get; set; }
    public string Comments { get; set; }
    
    public Guid DepartmenId { get; set; }
}