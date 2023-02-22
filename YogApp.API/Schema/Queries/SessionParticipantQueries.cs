using YogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using YogApp.Infrastructure.Repositories;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Rooms;

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
    public static SessionParticipantEntity? GetSessionParticipant([Service] ISessionParticipantRepository repo, Guid id)
    {
        return repo.GetById(id);
    }
}
