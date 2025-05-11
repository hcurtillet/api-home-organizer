using HomeOrganizer.Domain.Entities;

namespace HomeOrganizer.Application.Homes.Commands.AddUserAccountToHome;

public class AddUserAccountToHomeResponse
{
    public Home Home { get; }
    public AddUserAccountToHomeResponse(Home home)
    {
        Home = home;
    }
}