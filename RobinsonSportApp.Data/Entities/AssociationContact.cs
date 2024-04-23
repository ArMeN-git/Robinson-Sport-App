namespace RobinsonSportApp.Data.Entities;

public class AssociationContact
{
    public int AssociationId { get; set; }
    public Association Association { get; set; }
    public int ContactPersonId { get; set; }
    public ContactPerson ContactPerson { get; set; }
}
