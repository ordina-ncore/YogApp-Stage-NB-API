using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;

using YogApp.Infrastructure.Data;
using YogApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services //register db context didnt work here, zie sample
    .AddGraphQLServer()
    .AddAuthorization()
    .AddHttpRequestInterceptor<HttpRequestInterceptor>()
    .AddFiltering()
    .AddSorting()
    .AddTypes()
    .AddInMemorySubscriptions();



builder.Services.AddAuthorization();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration, configSectionName:"AzureAdConfiguration");


builder.Services.AddCors().AddPooledDbContextFactory<YogAppDbContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(builder
        .Configuration
        .GetConnectionString("yogappdb")));

builder.Services.AddDbContext<YogAppDbContext>();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IAzureService, AzureService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<ISessionParticipantRepository, SessionParticipantRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddErrorFilter<GraphQLErrorFilter>();
builder.Services.AddMsGraphConfiguration(builder.Configuration);


builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(7242, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});
var app = builder.Build();



app.UseCors(corsOptions => corsOptions
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()
        )
    .UseRouting();

app.CreateDbIfNotExists();
// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthentication().UseAuthorization();

app.UseWebSockets();
app.MapGraphQL();

app.Run();
