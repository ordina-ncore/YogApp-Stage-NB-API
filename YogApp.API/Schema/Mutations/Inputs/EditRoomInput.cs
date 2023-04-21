namespace YogApp.API.Schema.Mutations.Inputs
{
    public class EditRoomInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
    }
}
