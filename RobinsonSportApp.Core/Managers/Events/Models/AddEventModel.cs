using RobinsonSportApp.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace RobinsonSportApp.Core.Managers.Events.Models;

public class AddEventModel
{
    [Required]
    public string Opponent1 { get; set; }

    [Required]
    public string Opponent2 { get; set; }
    public string Opponent1Logo { get; set; }
    public string Opponent2Logo { get; set; }
    public float Score1 { get; set; }
    public float Score2 { get; set; }
    [Required]
    public string Place { get; set; }

    [Required]
    public string Address { get; set; }
    [Required]
    public SportCategory SportCategory { get; set; }

    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public TimeOnly StartTime { get; set; }
    public DateTime EndDate { get; set; }
    public TimeOnly EndTime { get; set; }
}
