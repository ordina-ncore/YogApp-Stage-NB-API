using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Rooms;
using YogApp.Domain.Sessions;
using YogApp.Domain.Users;

namespace YogApp.Domain.SessionParticipants
{
    public class SessionParticipantDomain
    {
        public SessionParticipantEntity entity { get; }
        private SessionParticipantDomain(Guid id, int matNumber,string timeStampSignUp, bool hasCancelled, UserEntity user, bool isDeleted)
        {
            entity = new SessionParticipantEntity()
            {
                Id = id,
                MatNumber = matNumber,
                TimeStampSignUp= timeStampSignUp,
                HasCancelled= hasCancelled,
                User = user,
                IsDeleted = isDeleted
            };
        }
        private SessionParticipantDomain(SessionParticipantEntity entity) => this.entity = entity;

        public static SessionParticipantDomain Create(SessionParticipantEntity entity)
        {
            return new SessionParticipantDomain(entity);
        }
        public static SessionParticipantDomain Create(int matNumber, UserEntity user)
        {
            return new SessionParticipantDomain(
                Guid.NewGuid(),
                matNumber,
                DateTime.Now.ToUniversalTime().ToString(),
                false,
                user,
                false
                );
        }
        //methods
    }
}
