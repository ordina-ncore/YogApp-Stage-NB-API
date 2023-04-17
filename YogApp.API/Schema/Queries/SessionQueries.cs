using YogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using YogApp.Infrastructure.Repositories;
using YogApp.Domain.Sessions;
using HotChocolate.Authorization;

namespace YogApp.API.Schema.Queries;

[QueryType]
public static class SessionQueries
{

    [UsePaging]
    [UseSorting]
    [UseFiltering]
    [Authorize(Roles = new[] { "User", "Teacher" })]
    public static List<SessionEntity> GetSessions([Service] ISessionRepository repo, [Service] IAzureService azureService)
    {
        return repo.GetAll();
    }
    [Authorize(Roles = new[] { "User", "Teacher" })]
    public static SessionEntity? GetSession([Service] ISessionRepository repo, Guid id)
    {
        return repo.GetById(id);
    }
}
