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

        CreateMap<AddEventModel, Event>();

        CreateMap<UpdateEventModel, Event>();

        // Associations
        CreateMap<Association, AssociationModel>();

        CreateMap<UpdateAssociationModel, Association>();

        // Event comments
        CreateMap<EventComment, EventCommentModel>();

        CreateMap<AddCommentModel, EventComment>();
    }
}
