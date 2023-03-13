namespace YogApp.API
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if(error != null )return error.WithMessage(error.Exception.Message);
            return null;
        }
    }
}
