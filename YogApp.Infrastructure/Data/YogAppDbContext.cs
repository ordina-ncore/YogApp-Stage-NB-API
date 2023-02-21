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

           
        }

    }
}
