using YogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using YogApp.Infrastructure.Repositories;
using YogApp.Domain.Sessions;

namespace YogApp.API.Schema.Queries;

[QueryType]
public static class SessionQueries
{

    [UsePaging]
    [UseSorting]
    [UseFiltering]
    public static List<SessionEntity> GetSessions([Service] ISessionRepository repo)
    {
        return repo.GetAll();
    }
    public static SessionEntity? GetSession([Service] ISessionRepository repo, Guid id)
    {
        return repo.GetById(id);
    }
}
