namespace YogApp.API.Schema.Mutations.Inputs
{
    public class CreateUserInput
    {
        public string AzureId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
    }
}
