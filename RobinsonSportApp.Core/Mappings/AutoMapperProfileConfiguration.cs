using AutoMapper;
using RobinsonSportApp.Core.Managers.Events.Models;
using RobinsonSportApp.Data.Entities;

namespace RobinsonSportApp.Core.Mappings;

public class AutoMapperProfileConfiguration : Profile
{
    public AutoMapperProfileConfiguration()
    {
        CreateMap<Event, EventModel>();

        CreateMap<Event, EventDetailedModel>();

        CreateMap<AddEventModel, Event>();
    }
}
