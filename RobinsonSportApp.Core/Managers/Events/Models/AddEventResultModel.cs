using System.ComponentModel.DataAnnotations;

namespace RobinsonSportApp.Core.Managers.Events.Models;

public class AddEventResultModel
{
    [Range(0, long.MaxValue)]
    public long Id { get; set; }

    [Range(0, 10000)]
    public float Score1 { get; set; }

    [Range(0, 10000)]
    public float Score2 { get; set; }
}
