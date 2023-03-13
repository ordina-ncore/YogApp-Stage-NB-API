using YogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using YogApp.Infrastructure.Repositories;
using YogApp.Domain.Users;
using YogApp.Domain.Sessions;

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
    public static UserEntity? GetUser([Service] IUserRepository repo, Guid id)
    {
        return repo.GetById(id);
    }
    public static UserEntity? GetUserByAzureId([Service] IUserRepository repo, string azureId)
    {
        return repo.GetByAzureId(azureId);
    }
}
