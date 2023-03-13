using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogApp.Domain.Exceptions
{

    public class RoomUnavailableException : Exception
    {
        public RoomUnavailableException() : base("The selected room is unavailable during the chosen timeslot")
        {
        }
    }
    public class ParticipantsExceedRoomCapacityException : Exception
    {
        public ParticipantsExceedRoomCapacityException() : base("The maximum number of participants exceeds the capacity of the selected room")
        {
        }
    }
    public class SessionCanNotBeInThePastException : Exception
    {
        public SessionCanNotBeInThePastException() : base("You can not create a session in the past")
        {
        }
    }
    public class SessionTooShortException : Exception
    {
        public SessionTooShortException() : base("A session must at least be 15 minutes long")
        {
        }
    }
    public class SessionStartTimeBeforeSessionEndtimeException : Exception
    {
        public SessionStartTimeBeforeSessionEndtimeException() : base("The session must end after it has started")
        {
        }
    }
    public class NoRoomSelectedException : Exception
    {
        public NoRoomSelectedException() : base("Please select a room")
        {
        }
    }
}
