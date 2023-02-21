﻿using YogApp.Domain.Rooms;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Users;

namespace YogApp.Domain.Sessions;

public class SessionDomain
{
    public SessionEntity entity { get; }
    private SessionDomain(Guid id, string title, DateTime start, DateTime end, int capacity, UserEntity teacher, string timeAdded, bool isCancelled, bool isFull,RoomEntity room, List<SessionParticipantEntity> participants, bool isDeleted)
    {
        entity = new SessionEntity()
        {
            Id = id,
            Title = title,
            StartDateTime = start,
            EndDateTime = end,
            Capacity = capacity,
            Teacher = teacher,
            TimeStampAdded = timeAdded,
            IsCancelled = isCancelled,
            IsFull = isFull,
            Room = room,
            Participants = participants,
            IsDeleted = isDeleted
        };
    }
    private SessionDomain(SessionEntity entity) => this.entity = entity;

    public static SessionDomain Create(SessionEntity entity)
    {
        return new SessionDomain(entity);
    }
    public static SessionDomain Create(string title, DateTime start, DateTime end, int capacity, UserEntity teacher, RoomEntity room)
    {
        return new SessionDomain(
            new Guid(), 
            title,
            start,
            end,
            capacity,
            teacher,
            DateTime.Now.ToString(),
            false,
            false,
            room,
            null,
            false
            );
    }
    //hier methods

}
