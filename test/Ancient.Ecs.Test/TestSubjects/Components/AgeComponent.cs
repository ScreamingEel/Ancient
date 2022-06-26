namespace Ancient.Ecs.Test.TestSubjects.Components;
public class AgeComponent : EntityComponentBase
{
    public int Age { get; set; }
    public AgeComponent(int age = 18)
    {
        Age = age;
    }
}
