namespace YogApp.API.Schema.Mutations.Inputs
{
    public class CreatUserInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
