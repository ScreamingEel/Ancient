namespace Ancient.Ecs.Test.TestSubjects;
public class TestComponent : IEntityComponent
{
    public char Value { get; set; }

    public TestComponent(char value)
    {
        Value = value;
    }
}
