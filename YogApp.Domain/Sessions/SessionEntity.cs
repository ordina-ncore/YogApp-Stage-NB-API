using System.ComponentModel.DataAnnotations;
using YogApp.Domain.Rooms;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Shared;
using YogApp.Domain.Users;

namespace YogApp.Domain.Sessions;

public class SessionEntity : EntityBase
{
    public string Title { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int Capacity { get; set; }
    public UserEntity Teacher { get; set; }
    [Timestamp]
    public string TimeStampAdded { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsFull { get; set; }
    public RoomEntity Room { get; set; }
    public List<SessionParticipantEntity>? Participants { get; set; }


}
