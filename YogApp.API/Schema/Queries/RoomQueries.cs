﻿using YogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using YogApp.Domain.Rooms;
using YogApp.Infrastructure.Repositories;
using YogApp.Domain.Sessions;
using HotChocolate.Authorization;

namespace YogApp.API.Schema.Queries;

[QueryType]
public static class RoomQueries
{

    [UsePaging]
    [UseSorting]
    [UseFiltering]
    [Authorize(Roles = new[] {"Teacher" })]
    public static List<RoomEntity> GetRooms([Service] IRoomRepository repo)
    {
        return repo.GetAll();
    }
    [Authorize(Roles = new[] {"Teacher", "User"})]
    public static RoomEntity? GetRoom([Service] IRoomRepository repo, Guid id)
    {
        return repo.GetById(id);
    }
}
