using Microsoft.EntityFrameworkCore;
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
    public class YogAppDbContext: DbContext
    {
        public YogAppDbContext(DbContextOptions<YogAppDbContext> options): base(options)
        {
        }

        public DbSet<UserEntity> users => Set<UserEntity>();
        public DbSet<RoomEntity> rooms => Set<RoomEntity>();
        public DbSet<SessionParticipantEntity> sessionParticipants => Set<SessionParticipantEntity>();
        public DbSet<SessionEntity> sessions => Set<SessionEntity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //KEYS
            builder.Entity<UserEntity>().HasKey(x => x.Id);
            builder.Entity<RoomEntity>().HasKey(x => x.Id);
            builder.Entity<SessionParticipantEntity>().HasKey(x => x.Id);
            builder.Entity<SessionEntity>().HasKey(x => x.Id);

            //CHILDREN
            //builder.Entity<SessionEntity>().HasMany(x => x.Participants);

            //USERS
            UserDomain ud1 = UserDomain.Create("Nathan", "Boone", "https://pbs.twimg.com/media/FjU2lkcWYAgNG6d.jpg", new DateOnly(2002, 03, 07));
            UserDomain ud2 = UserDomain.Create("Anouk", "As", "https://pbs.twimg.com/media/FmSgc2-aAAIXH80.jpg", new DateOnly(1998, 07, 25));
            UserDomain ud3 = UserDomain.Create("Michiel", "Jans", "https://pbs.twimg.com/media/FjYAoHEXgAMUIQX.jpg", new DateOnly(2003, 08, 02));
            UserDomain ud4 = UserDomain.Create("Fayssal", "Ghojdam", "https://pbs.twimg.com/media/FksaOPPacAAxj8i.jpg", new DateOnly(2000, 11, 18));

            // EERST DEZE AFMAKEN EN DAN IN SESSION DOMAI GEBRUIKEN AS TEACHER UserDomain udTeacher = UserDomain.Create("Kevin", "Yoga", "https://pbs.twimg.com/media/FksaOPPacAAxj8i.jpg", new DateOnly(2000, 11, 18));

            //ROOMS
            RoomDomain rd1 = RoomDomain.Create("Room L 1", "BlarenbergLaan 1, 1564 mechelen", 25);
            RoomDomain rd2 = RoomDomain.Create("Room S 2", "BlarenbergLaan 1, 1564 mechelen", 15);
            RoomDomain rd3 = RoomDomain.Create("Room XS 2", "BlarenbergLaan 1, 1564 mechelen", 10);

            //SESSIONPARTICIPANTS
            SessionParticipantDomain spd1 = SessionParticipantDomain.Create(2, ud2.entity);
            SessionParticipantDomain spd2 = SessionParticipantDomain.Create(5, ud3.entity);
            SessionParticipantDomain spd3 = SessionParticipantDomain.Create(8, ud1.entity);

            SessionParticipantDomain spd4 = SessionParticipantDomain.Create(15, ud1.entity);
            SessionParticipantDomain spd5 = SessionParticipantDomain.Create(6, ud4.entity);

            SessionParticipantDomain spd6 = SessionParticipantDomain.Create(1, ud3.entity);

            // HIER AFMAKEN SessionDomain sd1 = SessionDomain.Create("Introductiesessie voor beginners", new DateTime(2023,03,05,15,30,00), new DateTime(2023, 03, 05, 16, 30, 00), 5)

            //builder.Entity<UserEntity>().HasData(ud1, ud2, ud3, ud4);
            //builder.Entity<RoomEntity>().HasData(rd1, rd2, rd3);

        }

    }
}
