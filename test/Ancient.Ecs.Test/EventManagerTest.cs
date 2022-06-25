namespace Ancient.Ecs.Test;
public class EventManagerTest
{
    private readonly EventManager _sut;
    private readonly Mock<EntityManager> _entityManagerMock;

    public EventManagerTest()
    {
        _sut = new EventManager();
        _entityManagerMock = new();
    }

    private NameSystem CreateNameSystem() => new NameSystem(_entityManagerMock.Object, _sut);

    [Theory, AutoData]
    public void TestInvokeEvent(NameComponent nameComponent)
    {
        _entityManagerMock.Setup(m => m.GetComponent<It.IsAnyType>(0)).Returns(nameComponent);

        _sut.InvokeEvent(new FirstNameChangedEvent(0));

        nameComponent.FirstName.Should().BeEquivalentTo("Test successful");
    }
}
