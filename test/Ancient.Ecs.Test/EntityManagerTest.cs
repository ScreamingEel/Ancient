namespace Ancient.Ecs.Test;
public class EntityManagerTest
{
    private EntityManager _sut;

    public EntityManagerTest()
    {
        _sut = new();
    }

    private void ConfigureSutComplete()
    {
        EntityManagerConfiguration configuration = new();
        configuration.AddComponentSet<TestComponent>();
        configuration.AddComponentSet<NameComponent>();
        configuration.AddComponentSet<AgeComponent>();
        _sut = new(configuration);
    }

    private void CreateDummyEntities(int amount)
    {
        for (int i = 0; i < amount; i++)
            _sut.CreateEntity();
    }

    [Fact]
    public void TestCreateEntity()
    {
        _sut.CreateEntity().Should().Be(0);

        CreateDummyEntities(100);

        _sut.CreateEntity().Should().Be(101);

        _sut.CountEntities().Should().Be(102);
    }

    [Fact]
    public void TestRemoveEntity()
    {
        CreateDummyEntities(10);

        for (int i = 0; i < 5; i++)
            _sut.RemoveEntity(i);

        _sut.CountEntities().Should().Be(5);
    }

    [Fact]
    public void TestCreateEntityFillsEmptySpots()
    {
        CreateDummyEntities(10);
        _sut.RemoveEntity(2);

        int entity = _sut.CreateEntity();

        entity.Should().Be(2);

        _sut.RemoveEntity(3);
        _sut.RemoveEntity(6);
        _sut.RemoveEntity(9);

        _sut.CreateEntity().Should().Be(3);
        _sut.CreateEntity().Should().Be(6);
        _sut.CreateEntity().Should().Be(9);
    }

    [Theory, AutoData]
    public void TestAddComponent(TestComponent testComponent)
    {
        ConfigureSutComplete();
        
        _sut.AddComponent(0, testComponent);
        var result = _sut.GetComponent<TestComponent>(0);

        result.Should().BeOfType<TestComponent>()
            .Which.Value.Should().BeEquivalentTo(testComponent.Value);
    }

    [Theory, AutoData]
    public void TestAddComponentShouldThrowExceptionWhenComponentSetNotExists(TestComponent testComponent)
    {
        _sut.Invoking(sut => sut.AddComponent(0, testComponent))
            .Should().Throw<ComponentSetNotExistException>().Which.Message.Should()
                .BeEquivalentTo("EntityManager does not contain a ComponentSet for Component TestComponent");
    }

    [Theory, AutoData]
    public void TestAddDifferentComponents(TestComponent testComponent, NameComponent nameComponent)
    {
        ConfigureSutComplete();

        _sut.AddComponent(0, testComponent);
        _sut.AddComponent(1, nameComponent);

        _sut.GetComponent<TestComponent>(0)
            .Should().BeOfType<TestComponent>()
            .Which.Value.Should().BeEquivalentTo(testComponent.Value);
        _sut.GetComponent<NameComponent>(1)
            .Should().BeOfType<NameComponent>()
            .Which.Name.Should().BeEquivalentTo(nameComponent.Name);
    }

    [Fact]
    public void TestGetComponentShouldThrowExceptionWhenComponentSetNotExists()
    {
        _sut.Invoking(sut => sut.GetComponent<TestComponent>(0))
            .Should().Throw<ComponentSetNotExistException>().Which.Message.Should()
                .BeEquivalentTo("EntityManager does not contain a ComponentSet for Component TestComponent");
    }

    [Fact]
    public void TestGetComponentShouldReturnNullWhenComponentNotExist()
    {
        ConfigureSutComplete();

        var result = _sut.GetComponent<TestComponent>(0);

        result.Should().BeNull();
    }

    [Theory, AutoData]
    public void TestGetAllComponents(List<TestComponent> testComponents)
    {
        ConfigureSutComplete();
        for (int i = 0; i < testComponents.Count; i++)
            _sut.AddComponent<TestComponent>(i, testComponents[i]);

        var result = _sut.GetAllComponents<TestComponent>();

        result.Should().Contain(testComponents);
    }

    [Fact]
    public void TestSetEntityIdForEntityComponentBase()
    {
        ConfigureSutComplete();
        AgeComponent ageComponent = new AgeComponent();

        _sut.AddComponent(20, ageComponent);

        ageComponent.EntityId.Should().Be(20);
    }
}
