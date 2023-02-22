using YogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using YogApp.Infrastructure.Repositories;
using YogApp.Domain.Users;

namespace YogApp.API.Schema.Queries;

[QueryType]
public static class UserQueries
{

    [UsePaging]
    [UseSorting]
    [UseFiltering]
    public static List<UserEntity> GetUsers([Service] IUserRepository repo)
    {
        return repo.GetAll();
    }
}
