using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Rooms;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Sessions;

namespace YogApp.Domain.Users
{
    public class UserDomain
    {
        public UserEntity entity { get; }
        private UserDomain(Guid id, string? azureId, string firstName, string lastName, string profilePicture, DateOnly birthDate, bool isAdmin, bool isDeleted)
        {
            entity = new UserEntity()
            {
                Id = id,
                AzureId = azureId,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture,
                BirthDate = birthDate,
                IsAdmin = isAdmin,
                IsDeleted = isDeleted
            };
        }
        private UserDomain(UserEntity entity) => this.entity = entity;

        public static UserDomain Create(UserEntity entity)
        {
            return new UserDomain(entity);
        }
        public static UserDomain Create(string firstName, string lastName, string profilePicture, DateOnly birthDate)
        {
            return new UserDomain(
                new Guid(),
                null,
                firstName,
                lastName,
                profilePicture,
                birthDate,
                false,
                false
                );
        }
    }
}
