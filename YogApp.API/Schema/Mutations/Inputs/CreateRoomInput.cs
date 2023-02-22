namespace YogApp.API.Schema.Mutations.Inputs
{
    public class CreateRoomInput
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
    }
}
