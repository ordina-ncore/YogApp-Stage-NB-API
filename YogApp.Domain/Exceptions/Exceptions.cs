using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogApp.Domain.Exceptions
{

    public class RoomUnavailableException : Exception
    {
        public RoomUnavailableException() : base("RoomUnavailableException")
        {
        }
    }
    public class ParticipantsExceedRoomCapacityException : Exception
    {
        public ParticipantsExceedRoomCapacityException() : base("ParticipantsExceedRoomCapacityException")
        {
        }
    }
    public class SessionCanNotBeInThePastException : Exception
    {
        public SessionCanNotBeInThePastException() : base("SessionCanNotBeInThePastException")
        {
        }
    }
    public class SessionTooShortException : Exception
    {
        public SessionTooShortException() : base("SessionTooShortException")
        {
        }
    }
    public class SessionStartTimeBeforeSessionEndtimeException : Exception
    {
        public SessionStartTimeBeforeSessionEndtimeException() : base("SessionStartTimeBeforeSessionEndtimeException")
        {
        }
    }
    public class NoRoomSelectedException : Exception
    {
        public NoRoomSelectedException() : base("NoRoomSelectedException")
        {
        }
    }
    public class CapacityCanNotBeSmallerThanAmountOfParticipantsException : Exception
    {
        public CapacityCanNotBeSmallerThanAmountOfParticipantsException() : base("CapacityCanNotBeSmallerThanAmountOfParticipantsException")
        {
        }
    }
    public class CanotNotSignUpForTakenMatException : Exception
    {
        public CanotNotSignUpForTakenMatException() : base("CanotNotSignUpForTakenMatException")
        {
        }
    }
    public class CanNotReduceCapacityIfRoomIsPlannedForUpcomingSessionException : Exception
    {
        public CanNotReduceCapacityIfRoomIsPlannedForUpcomingSessionException() : base("CanNotReduceCapacityIfRoomIsPlannedForUpcomingSessionException")
        {
        }
    }
    public class CanNotDeleteRoomIfRoomIsPlannedForUpcomingSessionException : Exception
    {
        public CanNotDeleteRoomIfRoomIsPlannedForUpcomingSessionException() : base("CanNotDeleteRoomIfRoomIsPlannedForUpcomingSessionException")
        {
        }
    }
}
