using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Rooms;

namespace YogApp.DomainTests
{
    public class RoomDomainTests
    {
        [Test]
        public void CreateWithValidInputs()
        {
            // Arrange
            string name = "Test Room";
            string address = "123 Main St";
            int capacity = 10;

            // Act
            var entity = RoomDomain.Create(name, address, capacity).entity;

            // Assert
            Assert.That(entity.Name, Is.SameAs(name));
            Assert.That(entity.Address, Is.SameAs(address));
            Assert.That(entity.Capacity, Is.EqualTo(capacity));
            Assert.That(entity.IsDeleted, Is.False);
        }

        [Test]
        public void CreateWithRoomEntity()
        {
            // Arrange
            var entity = new RoomEntity
            {
                Id = Guid.NewGuid(),
                Name = "Test Room",
                Address = "123 Main St",
                Capacity = 10,
                IsDeleted = false
            };

            // Act
            var roomDomain = RoomDomain.Create(entity);

            // Assert
            Assert.That(roomDomain.entity, Is.EqualTo(entity));
        }

    }
}
