using Microsoft.Graph.Models.CallRecords;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.API;
using YogApp.Domain.Exceptions;
using YogApp.Domain.Rooms;
using YogApp.Domain.Sessions;
using YogApp.Domain.Users;

namespace YogApp.DomainTests
{
    public class SessionDomainTests
    {
        private string _teacher;
        private RoomEntity _room;
        private DateTime _start;
        private DateTime _end;
        private int _capacity;

        public SessionDomainTests()
        {
            _teacher = "ergezbzbsb";
            _room = new RoomEntity() { Capacity = 10 };
            _start = DateTime.UtcNow.AddHours(1);
            _end = _start.AddHours(2);
            _capacity = 5;
        }

        [Test]
        public void Create_WhenCapacityExceedsRoomCapacity_ShouldThrowParticipantsExceedRoomCapacityException()
        {
            // Arrange
            int capacity = _room.Capacity + 1;

            // Act & Assert
            Assert.Throws<ParticipantsExceedRoomCapacityException>(() =>
                SessionDomain.Create("Title", _start, _end, capacity, _teacher, _room, null));
        }

        [Test]
        public void Create_WhenStartTimeIsInThePast_ShouldThrowSessionCanNotBeInThePastException()
        {
            // Arrange
            DateTime start = DateTime.UtcNow.AddHours(-1);

            // Act & Assert
            Assert.Throws<SessionCanNotBeInThePastException>(() =>
                SessionDomain.Create("Title", start, _end, _capacity, _teacher, _room, null));
        }

        [Test]
        public void Create_WhenStartTimeIsAfterEndTime_ShouldThrowSessionStartTimeBeforeSessionEndtimeException()
        {
            // Arrange
            DateTime start = _end;
            DateTime end = _start;

            // Act & Assert
            Assert.Throws<SessionStartTimeBeforeSessionEndtimeException>(() =>
                SessionDomain.Create("Title", start, end, _capacity, _teacher, _room, null));
        }

        [Test]
        public void Create_WhenSessionDurationIsTooShort_ShouldThrowSessionTooShortException()
        {
            // Arrange
            TimeSpan duration = new TimeSpan(0, 10, 0);
            DateTime end = _start.Add(duration);

            // Act & Assert
            Assert.Throws<SessionTooShortException>(() =>
                SessionDomain.Create("Title", _start, end, _capacity, _teacher, _room, null));
        }

        [Test]
        public void Cancel_EnsureThatIsCancelledIsTrue()
        {
            // Arrange
            SessionEntity entity = SessionDomain.Create("Title", _start, _end, _capacity, _teacher, _room, null).entity;
            SessionService sessionservice = new SessionService();

            entity = sessionservice.CancelSession(entity);
            // Act & Assert
            Assert.That(entity.IsCancelled, Is.EqualTo(true));
        }

        [Test]
        public void Create_WhenParametersAreValid_ShouldCreateSessionDomain()
        {
            // Act
            var session = SessionDomain.Create("Title", _start, _end, _capacity, _teacher, _room, null);

            // Assert
            Assert.NotNull(session);
            Assert.NotNull(session.entity);
            Assert.That(session.entity.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(session.entity.Title, Is.EqualTo("Title"));
            Assert.That(session.entity.StartDateTime, Is.EqualTo(_start.ToUniversalTime()));
            Assert.That(session.entity.EndDateTime, Is.EqualTo(_end.ToUniversalTime()));
            Assert.That(session.entity.Capacity, Is.EqualTo(_capacity));
            Assert.That(session.entity.TeacherAzureId, Is.EqualTo(_teacher));
            Assert.That(session.entity.Room, Is.EqualTo(_room));
            Assert.That(session.entity.Participants, Is.Empty);
            Assert.False(session.entity.IsCancelled);
            Assert.False(session.entity.IsFull);
            Assert.False(session.entity.IsDeleted);
        }
    }
}
