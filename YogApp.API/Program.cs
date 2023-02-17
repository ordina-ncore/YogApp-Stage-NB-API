var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddTypes();

var app = builder.Build();

//app.UseAuthorization();

app.MapGraphQL();

app.Run();
