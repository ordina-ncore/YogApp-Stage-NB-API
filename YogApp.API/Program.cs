using Microsoft.EntityFrameworkCore;
using YogApp.Infrastructure.Data;
using YogApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services //register db context didnt work here, zie sample
    .AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    .AddTypes();

builder.Services.AddCors().AddPooledDbContextFactory<YogAppDbContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(builder
        .Configuration
        .GetConnectionString("yogappdb")));

builder.Services.AddDbContext<YogAppDbContext>();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISessionParticipantRepository, SessionParticipantRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();


var app = builder.Build();

app.UseCors(corsOptions => corsOptions
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()
        )
    .UseRouting();

app.CreateDbIfNotExists();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapGraphQL();

app.Run();
