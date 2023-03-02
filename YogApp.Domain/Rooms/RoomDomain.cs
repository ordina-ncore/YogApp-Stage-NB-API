using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Rooms;
using YogApp.Domain.Sessions;
using YogApp.Domain.Users;

namespace YogApp.Domain.Rooms
{
    public class RoomDomain
    {
        public RoomEntity entity { get; }
        private RoomDomain(Guid id, string name, string address, int capacity, bool isDeleted)
        {
            entity = new RoomEntity()
            {
                Id = id,
                Name = name,
                Address = address,
                Capacity = capacity,
                IsDeleted = isDeleted
            };
        }
        private RoomDomain(RoomEntity entity) => this.entity = entity;

        public static RoomDomain Create(RoomEntity entity)
        {
            return new RoomDomain(entity);
        }
        public static RoomDomain Create(string name, string address, int capacity)
        {
            return new RoomDomain(
                Guid.NewGuid(),
                name,
                address,
                capacity,
                false
                );
        }

        //methods
    }
}
