namespace YogApp.API.Schema.Mutations;

[MutationType]
public static class Mutation
{
    public static string TestMutation(string value)
    {
        return $"your value: {value}";
    }
}