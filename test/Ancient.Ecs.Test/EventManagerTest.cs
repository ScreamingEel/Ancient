namespace Ancient.Ecs.Test;
public class EventManagerTest
{
    private readonly EventManager _sut;
    private readonly Mock<IEntityManager> _entityManagerMock;

    public EventManagerTest()
    {
        _sut = new EventManager();
        _entityManagerMock = new();
    }

    private NameSystem CreateNameSystem(string changeNameTo = "Test successful") 
        => new NameSystem(_entityManagerMock.Object, _sut, changeNameTo);

    [Theory, AutoData]
    public void TestInvokeEvent(NameComponent nameComponent)
    {
        _entityManagerMock.Setup(m => m.GetComponent<NameComponent>(0)).Returns(nameComponent);
        CreateNameSystem();

        _sut.InvokeEvent(new FirstNameChangedEvent(0));

        nameComponent.FirstName.Should().BeEquivalentTo("Test successful");
    }

    [Theory, AutoData]
    public void TestInvokeEventTwice(NameComponent nameComponent)
    {
        _entityManagerMock.Setup(m => m.GetComponent<NameComponent>(0)).Returns(nameComponent);
        CreateNameSystem();
        CreateNameSystem("Second test successful");

        _sut.InvokeEvent(new FirstNameChangedEvent(0));

        _entityManagerMock.Verify(m => m.GetComponent<NameComponent>(0), Times.Exactly(2));
        nameComponent.FirstName.Should().BeEquivalentTo("Second test successful");
    }

    [Theory, AutoData]
    public void TestRemoveSubscription(NameComponent nameComponent)
    {
        nameComponent.FirstName = "Nothing changed";
        var system = CreateNameSystem();
        system.RemoveSubscription();

        _sut.InvokeEvent(new FirstNameChangedEvent(0));

        nameComponent.FirstName.Should().BeEquivalentTo("Nothing changed");
    }
}
