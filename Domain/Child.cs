namespace Domain;

public class Child
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<Present> Presents { get; set; }
}
