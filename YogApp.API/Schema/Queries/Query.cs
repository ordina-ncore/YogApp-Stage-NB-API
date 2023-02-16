namespace YogApp.API.Schema.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class Query
{
    public string TestQuery()
    {
        return "this is a query";
    }
}
