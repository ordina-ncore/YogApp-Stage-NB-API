using YogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using YogApp.Domain.Rooms;
using YogApp.Infrastructure.Repositories;
using YogApp.Domain.Sessions;

namespace YogApp.API.Schema.Queries;

[QueryType]
public static class RoomQueries
{

    [UsePaging]
    [UseSorting]
    [UseFiltering]
    public static List<RoomEntity> GetRooms([Service] IRoomRepository repo)
    {
        return repo.GetAll();
    }
    public static RoomEntity? GetRoom([Service] IRoomRepository repo, Guid id)
    {
        return repo.GetById(id);
    }
}
