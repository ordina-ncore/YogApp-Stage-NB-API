using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Shared;
using YogApp.Domain.Users;

namespace YogApp.Domain.SessionParticipants
{
    public class SessionParticipantEntity: EntityBase
    {
        public int MatNumber { get; set; }
        [Timestamp]
        public string TimeStampSignUp { get; set; }
        public bool HasCancelled { get; set; }
        public UserEntity User { get; set; }

    }
}
