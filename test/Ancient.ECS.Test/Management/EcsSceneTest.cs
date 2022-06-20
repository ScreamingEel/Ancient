namespace Ancient.ECS.Management
{
    public class EcsSceneTest
    {
        private readonly EcsScene _sut;

        public EcsSceneTest()
        {
            _sut = new EcsScene();
        }

        [Theory, AutoData]
        public void TestAddEntity(Entity entity)
        {
            // Act
            _sut.AddEntity(entity);

            // Assert
            _sut.Entities.Should().HaveCount(1);
            entity.Id.Should().Be(1);
        }
    }
}
