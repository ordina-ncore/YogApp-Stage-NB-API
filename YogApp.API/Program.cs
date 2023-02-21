using Microsoft.EntityFrameworkCore;
using YogApp.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services //register db context didnt work here, zie sample
    .AddGraphQLServer()
    .AddTypes();

builder.Services.AddCors().AddPooledDbContextFactory<YogAppDbContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(builder
        .Configuration
        .GetConnectionString("yogappdb")));

builder.Services.AddDbContext<YogAppDbContext>();

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
