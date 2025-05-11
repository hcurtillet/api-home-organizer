using HomeOrganizer.Application.Common.Attributes;
using MediatR;

namespace HomeOrganizer.Application.Homes.Commands.CreateHome;

[Authenticated]
public class CreateHomeRequest: IRequest<CreateHomeResponse>
{
    public string Name { get; }

    public CreateHomeRequest(string name)
    {
        Name = name;
    }
}