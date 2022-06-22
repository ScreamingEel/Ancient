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
        _sut = new(configuration);
    }

    private void CustomSutConfiguration(EntityManagerConfiguration configuration)
    {
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

    [Fact]
    public void TestAddComponent()
    {
        ConfigureSutComplete();
        TestComponent testComponent = new TestComponent('A');
        _sut.AddComponent(0, testComponent);

        var result = _sut.GetComponent<TestComponent>(0);

        result.Should().BeOfType<TestComponent>()
            .Which.Value.Should().BeEquivalentTo(testComponent.Value);
    }
}
