using Leopotam.Ecs;


public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private SceneData sceneData;
    public void Init()
    {
        EcsEntity playerEntity = ecsWorld.NewEntity();
        ref var playerComponent = ref playerEntity.Get<PlayerComponent>();
    }
}