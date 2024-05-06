using AutoMapper;
using RobinsonSportApp.Core.Managers.Associations.Models;
using RobinsonSportApp.Core.Managers.EventComments.NewFolder;
using RobinsonSportApp.Core.Managers.Events.Models;
using RobinsonSportApp.Data.Entities;

namespace RobinsonSportApp.Core.Mappings;

public class AutoMapperProfileConfiguration : Profile
{
    public AutoMapperProfileConfiguration()
    {
        // Events
        CreateMap<Event, EventModel>();

        CreateMap<Event, EventDetailedModel>();

        CreateMap<AddEventModel, Event>()
            .ForMember(x => x.StartTime, opt => opt.MapFrom(a => new DateTime(a.StartDate.Year, a.StartDate.Month, a.StartDate.Day, a.StartTime.Hour, a.StartTime.Minute, a.StartTime.Second, DateTimeKind.Utc)))
            .ForMember(x => x.EndTime, opt => opt.MapFrom(a => new DateTime(a.EndDate.Year, a.EndDate.Month, a.EndDate.Day, a.EndTime.Hour, a.EndTime.Minute, a.EndTime.Second, DateTimeKind.Utc)));

        CreateMap<UpdateEventModel, Event>();

        // Associations
        CreateMap<Association, AssociationModel>();

        CreateMap<UpdateAssociationModel, Association>();

        // Event comments
        CreateMap<EventComment, EventCommentModel>();

        CreateMap<AddCommentModel, EventComment>();
    }
}
