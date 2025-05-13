namespace HomeOrganizer.Application.Common.Exceptions;

public class NotFoundException: Exception
{
    public NotFoundException(): base("Entity Not found") {}
    
    public NotFoundException(Guid id, Type type): base($"{type.Name} with id {id} not found") {} 
}