namespace Application;

public class ChildDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public ChildDto(Guid id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }
}
