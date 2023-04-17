using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Rooms;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Sessions;
using YogApp.Domain.Users;

namespace YogApp.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Initialize(YogAppDbContext context)
        {

            if (context.sessions.Any()) return;
        }
    }
}
