namespace Domain;

public class Present
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ChildId { get; set; }
    public Child Child { get; set; }
}
