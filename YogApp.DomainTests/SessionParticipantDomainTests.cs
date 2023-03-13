using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Users;

namespace YogApp.DomainTests
{
    public class SessionParticipantDomainTests
    {
        private UserEntity _testUser;

        [SetUp]
        public void Setup()
        {
            _testUser = new UserEntity
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateOnly(1990, 1, 1),
                ProfilePicture = "https://example.com/profile.jpg",
                IsAdmin = false
            };
        }

        [Test]
        public void Create_SessionParticipantEntity_ValidInput_ShouldReturnSessionParticipantDomain()
        {
            // Arrange
            var entity = new SessionParticipantEntity
            {
                Id = Guid.NewGuid(),
                MatNumber = 123,
                TimeStampSignUp = DateTime.UtcNow.ToString(),
                HasCancelled = false,
                User = _testUser,
                IsDeleted = false
            };

            // Act
            var domainObject = SessionParticipantDomain.Create(entity);

            // Assert
            Assert.IsNotNull(domainObject);
            Assert.That(domainObject.entity.Id, Is.EqualTo(entity.Id));
            Assert.That(domainObject.entity.MatNumber, Is.EqualTo(entity.MatNumber));
            Assert.That(domainObject.entity.TimeStampSignUp, Is.EqualTo(entity.TimeStampSignUp));
            Assert.That(domainObject.entity.HasCancelled, Is.EqualTo(entity.HasCancelled));
            Assert.That(domainObject.entity.User, Is.EqualTo(entity.User));
            Assert.That(domainObject.entity.IsDeleted, Is.EqualTo(entity.IsDeleted));
        }

        [Test]
        public void Create_MatNumberAndUserEntity_ValidInput_ShouldReturnSessionParticipantDomain()
        {
            // Arrange
            var matNumber = 123;
            var user = _testUser;

            // Act
            var domainObject = SessionParticipantDomain.Create(matNumber, user);

            // Assert
            Assert.IsNotNull(domainObject);
            Assert.That(domainObject.entity.MatNumber, Is.EqualTo(matNumber));
            Assert.That(domainObject.entity.User, Is.EqualTo(user));
            Assert.IsFalse(string.IsNullOrEmpty(domainObject.entity.TimeStampSignUp));
            Assert.IsFalse(domainObject.entity.HasCancelled);
            Assert.IsFalse(domainObject.entity.IsDeleted);
        }
    }
}
