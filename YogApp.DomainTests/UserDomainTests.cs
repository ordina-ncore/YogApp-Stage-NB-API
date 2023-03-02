using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Users;

namespace YogApp.DomainTests
{
    internal class UserDomainTests
    {
        [Test]
        public void CreateWithValidInput()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";
            string profilePicture = "https://example.com/profile.jpg";
            var birthDate = new DateOnly(2000, 1, 1);

            // Act
            var user = UserDomain.Create(firstName, lastName, profilePicture, birthDate);

            // Assert
            Assert.IsNotNull(user);
            Assert.IsNotNull(user.entity.Id);
            Assert.That(user.entity.FirstName, Is.EqualTo(firstName));
            Assert.That(user.entity.LastName, Is.EqualTo(lastName));
            Assert.That(user.entity.ProfilePicture, Is.EqualTo(profilePicture));
            Assert.That(user.entity.BirthDate, Is.EqualTo(birthDate));
            Assert.IsFalse(user.entity.IsAdmin);
            Assert.IsFalse(user.entity.IsDeleted);
        }

        [Test]
        public void CreateWithEntity()
        {
            // Arrange
            var userEntity = new UserEntity()
            {
                Id = Guid.NewGuid(),
                AzureId = null,
                FirstName = "Jane",
                LastName = "Doe",
                ProfilePicture = "https://example.com/jane.jpg",
                BirthDate = new DateOnly(1995, 1, 1),
                IsAdmin = true,
                IsDeleted = false
            };

            // Act
            var user = UserDomain.Create(userEntity);

            // Assert
            Assert.IsNotNull(user);
            Assert.That(user.entity, Is.EqualTo(userEntity));
        }
    }
}
