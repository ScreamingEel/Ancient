namespace Ancient.Ecs.Test.TestSubjects;
public class NameComponent : IEntityComponent
{
    public string Name { get; set; }

    public NameComponent(string name)
    {
        Name = name;
    }
}
