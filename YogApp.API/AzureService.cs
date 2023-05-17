using Azure.Identity;
using LanguageExt;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions;
using Realms.Sync;
using YogApp.Domain.Users;
using YogApp.Infrastructure.Migrations;
using User = YogApp.Domain.Users.User;

namespace YogApp.API
{
    public class AzureService: IAzureService
    {
        private readonly GraphServiceClient _graphClient;

        public AzureService(GraphServiceClient graphClient) 
        {
            _graphClient = graphClient;
        }

        public async Task<User> ResolveUser(string azureId)
        {          
            var user = await _graphClient.Users[azureId].GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "givenName", "surname", "photo" };
            });

            var firstName = user.GivenName;
            var lastName = user.Surname;
            var photoUrl = user.Photo?.AdditionalData["@odata.mediaEditLink"] as string;
            if (photoUrl == null) photoUrl = "https://www.pngitem.com/pimgs/m/22-223968_default-profile-picture-circle-hd-png-download.png";

            return new User
            {
                AzureId = azureId,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = photoUrl
            };
        }

        public async Task<List<User>> GetTeachers()
        {
            List<User> teacherList = new List<User>();
            var users = await _graphClient.Users.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] {"Id", "givenName", "surname", "photo" };
            });
            foreach (var user in users.Value)
            {
                var result = await _graphClient.Users[user.Id].AppRoleAssignments.GetAsync();
                var roleIds = result.Value;
                foreach(var roleId in roleIds)
                {
                    if(roleId.AppRoleId.ToString() == "53a02585-08f4-4ab9-b84d-3e26042ca94e")
                    {
                        var photoUrl = user.Photo?.AdditionalData["@odata.mediaEditLink"] as string;
                        if (photoUrl == null) photoUrl = "https://www.pngitem.com/pimgs/m/22-223968_default-profile-picture-circle-hd-png-download.png";
                        teacherList.Add(new User
                        {
                            AzureId = user.Id,
                            FirstName = user.GivenName,
                            LastName = user.Surname,
                            ProfilePicture = photoUrl
                        });
                    }
                }
            }
            return teacherList;
        }

        public async Task<bool> AddEventToCalendar(string azureId, string subject, string body, DateTime start, DateTime end)
        {
            //getCalendars();
            //    Get the user's calendar
            var calendar = await _graphClient.Users[azureId].Calendar.GetAsync();

            //    Create the new event
            var newEvent = new Event
            {
                Subject = subject,
                Body = new ItemBody { Content = body },
                Start = new DateTimeTimeZone { DateTime = start.ToString("o"), TimeZone = TimeZoneInfo.Local.Id },
                End = new DateTimeTimeZone { DateTime = end.ToString("o"), TimeZone = TimeZoneInfo.Local.Id }
            };

            //Add the event to the user's calendar
           // await _graphClient.Users[azureId].Calendar.Events.AddAsync(newEvent);

            return true;
        }
        public async Task<string> CreateCalendar()
        {
            var requestBody = new Calendar
            {
                Name = "Ordina Yoga",
            };
            var result = await _graphClient.Me.Calendars.PostAsync(requestBody);
            return result.Id;
        }

        public async Task<string> getCalendars()
        {
            var result = await _graphClient.Me.Calendars.GetAsync();
            int test = 2;
            return "calendarId";
        }
    }
}
