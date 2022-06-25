namespace Ancient.Ecs.Test.TestSubjects.Components;
public class NameComponent : IEntityComponent
{
    public string Name { get; set; }
    public string FirstName { get; set; } = string.Empty;

    public NameComponent(string name)
    {
        Name = name;
    }
}
