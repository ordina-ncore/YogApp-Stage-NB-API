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

            ////USERS
            //UserDomain ud1 = UserDomain.Create("Nathan", "Boone", "https://pbs.twimg.com/media/FjU2lkcWYAgNG6d.jpg", new DateOnly(2002, 03, 07));
            //UserDomain ud2 = UserDomain.Create("Anouk", "As", "https://pbs.twimg.com/media/FmSgc2-aAAIXH80.jpg", new DateOnly(1998, 07, 25));
            //UserDomain ud3 = UserDomain.Create("Michiel", "Jans", "https://pbs.twimg.com/media/FjYAoHEXgAMUIQX.jpg", new DateOnly(2003, 08, 02));
            //UserDomain ud4 = UserDomain.Create("Fayssal", "Ghojdam", "https://pbs.twimg.com/media/FksaOPPacAAxj8i.jpg", new DateOnly(2000, 11, 18));

            //UserDomain udTeacher = UserDomain.Create("Kevin", "Yoga", "https://pbs.twimg.com/media/FmynZRjWYAgEEpL.jpg", new DateOnly(1985, 10, 24));

            ////ROOMS
            //RoomDomain rd1 = RoomDomain.Create("Room L 1", "BlarenbergLaan 1, 1564 mechelen", 25);
            //RoomDomain rd2 = RoomDomain.Create("Room S 2", "BlarenbergLaan 1, 1564 mechelen", 15);
            //RoomDomain rd3 = RoomDomain.Create("Room XS 2", "BlarenbergLaan 1, 1564 mechelen", 10);

            ////SESSIONPARTICIPANTS
            //SessionParticipantDomain spd1 = SessionParticipantDomain.Create(2, ud2.entity);
            //SessionParticipantDomain spd2 = SessionParticipantDomain.Create(5, ud3.entity);
            //SessionParticipantDomain spd3 = SessionParticipantDomain.Create(8, ud1.entity);

            //SessionParticipantDomain spd4 = SessionParticipantDomain.Create(15, ud1.entity);
            //SessionParticipantDomain spd5 = SessionParticipantDomain.Create(6, ud4.entity);

            //SessionParticipantDomain spd6 = SessionParticipantDomain.Create(1, ud3.entity);

            //SessionEntity sd1 = SessionDomain.Create("Introductiesessie voor beginners", new DateTime(2023, 03, 05, 15, 30, 00), new DateTime(2023, 03, 05, 16, 30, 00), 5, udTeacher.entity, rd3.entity, new List<SessionParticipantEntity> { spd1.entity, spd2.entity, spd3.entity }).entity;
            //SessionEntity sd2 = SessionDomain.Create("Wekelijkse yogasessie", new DateTime(2023, 03, 07, 12, 00, 00), new DateTime(2023, 03, 05, 12, 45, 00), 15, udTeacher.entity, rd2.entity, new List<SessionParticipantEntity> { spd3.entity, spd4.entity, spd5.entity, spd6.entity }).entity;

            //context.users.AddRange(ud1.entity, ud2.entity, ud3.entity, ud4.entity, udTeacher.entity);
            //context.rooms.AddRange(rd1.entity, rd2.entity, rd3.entity);
            //context.sessionParticipants.AddRange(spd1.entity, spd2.entity, spd3.entity, spd4.entity, spd5.entity, spd6.entity);
            //context.sessions.AddRange(sd1, sd2);
            context.SaveChanges();
        }
    }
}
