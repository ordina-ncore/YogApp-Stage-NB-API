﻿using YogApp.Domain.Rooms;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Sessions;
using YogApp.Domain.Users;

namespace YogApp.API.Schema.Types
{
    public class SessionParticipantType : ObjectType<SessionParticipantEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<SessionParticipantEntity> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Name("SessionParticipant");
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.MatNumber);
            descriptor.Field(x => x.TimeStampSignUp);
            descriptor.Field(x => x.HasCancelled);
            descriptor.Field(x => x.UserAzureId);
            descriptor.Field("user").Type<UserType>().Resolve((context, ct) =>
            {
                string teacherAzureId = context.Parent<SessionParticipantEntity>().UserAzureId;
                IAzureService azureService = context.Service<IAzureService>(); //TODO FIX: 
                return azureService.ResolveUser(teacherAzureId);
            });
        }
    }
}
