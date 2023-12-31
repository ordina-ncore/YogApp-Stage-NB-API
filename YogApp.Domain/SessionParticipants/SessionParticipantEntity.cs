﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Shared;

namespace YogApp.Domain.SessionParticipants
{
    public class SessionParticipantEntity: EntityBase
    {
        public int MatNumber { get; set; }
        //[Timestamp]
        public string TimeStampSignUp { get; set; }
        public bool HasCancelled { get; set; }
        public string UserAzureId { get; set; }

    }
}
