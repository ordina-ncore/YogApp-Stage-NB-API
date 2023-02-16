using YogApp.API.Schema.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    //queries
    .AddQueryType()
        .AddTypeExtension<Query>();

var app = builder.Build();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapGraphQL();

app.Run();
