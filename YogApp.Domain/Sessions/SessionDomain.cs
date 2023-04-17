using System.Runtime.CompilerServices;
using YogApp.Domain.Exceptions;
using YogApp.Domain.Rooms;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Users;

namespace YogApp.Domain.Sessions;

public class SessionDomain
{
    public SessionEntity entity { get; }
    private SessionDomain(Guid id, string title, DateTime start, DateTime end, int capacity, string teacherAzureId, string timeAdded, bool isCancelled, bool isFull,RoomEntity room, List<SessionParticipantEntity> participants, bool isDeleted)
    {
        entity = new SessionEntity()
        {
            Id = id,
            Title = title,
            StartDateTime = start,
            EndDateTime = end,
            Capacity = capacity,
            TeacherAzureId = teacherAzureId,
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
    public static SessionDomain Create(string title, DateTime start, DateTime end, int capacity, string teacherAzureId, RoomEntity room, int? participantCount)
    {
        if (capacity > room.Capacity)
        {
            throw new ParticipantsExceedRoomCapacityException();
        };

        if (start < DateTime.UtcNow)
        {
            throw new SessionCanNotBeInThePastException();
        };

        if (start > end)
        {
            throw new SessionStartTimeBeforeSessionEndtimeException();
        }
        if(participantCount != null)
        {
            if (capacity < participantCount) throw new CapacityCanNotBeSmallerThanAmountOfParticipantsException();
        }

        TimeSpan minimumDuration = new TimeSpan(0, 15, 0); // 15 minutes
        TimeSpan sessionDuration = end - start;

        if (sessionDuration < minimumDuration)
        {

            throw new SessionTooShortException();
        }

        return new SessionDomain(
            Guid.NewGuid(),
            title,
            start.ToUniversalTime(),
            end.ToUniversalTime(),
            capacity,
            teacherAzureId,
            DateTime.Now.ToUniversalTime().ToString(),
            false,
            false,
            room,
            new List<SessionParticipantEntity>(),
            false
            );
    }
    public SessionEntity Edit(string title, DateTime start, DateTime end, int capacity, string teacherAzureId, RoomEntity room, int? participantCount)
    {
        if (capacity > room.Capacity)
        {
            throw new ParticipantsExceedRoomCapacityException();
        };

        if (start < DateTime.UtcNow)
        {
            throw new SessionCanNotBeInThePastException();
        };

        if (start > end)
        {
            throw new SessionStartTimeBeforeSessionEndtimeException();
        }
        if (participantCount != null)
        {
            if (capacity < participantCount) throw new CapacityCanNotBeSmallerThanAmountOfParticipantsException();
        }

        TimeSpan minimumDuration = new TimeSpan(0, 15, 0); // 15 minutes
        TimeSpan sessionDuration = end - start;

        if (sessionDuration < minimumDuration)
        {

            throw new SessionTooShortException();
        }


        this.entity.Capacity = capacity;
        this.entity.TeacherAzureId = teacherAzureId;
        this.entity.StartDateTime = start;
        this.entity.EndDateTime = end;
        this.entity.Room = room;
        this.entity.Title = title;

        return this.entity;
    }
}
