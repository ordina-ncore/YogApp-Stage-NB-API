using YogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using YogApp.Infrastructure.Repositories;
using YogApp.Domain.SessionParticipants;

namespace YogApp.API.Schema.Queries;

[QueryType]
public static class SessionParticipantQueries
{

    [UsePaging]
    [UseSorting]
    [UseFiltering]
    public static List<SessionParticipantEntity> GetSessionParticipants([Service] ISessionParticipantRepository repo)
    {
        return repo.GetAll();
    }
}
