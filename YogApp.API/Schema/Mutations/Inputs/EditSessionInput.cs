namespace YogApp.API.Schema.Mutations.Inputs
{
    public class EditSessionInput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int Capacity { get; set; }

        public string TeacherId { get; set; }

        public Guid RoomId { get; set; }
    }
}
