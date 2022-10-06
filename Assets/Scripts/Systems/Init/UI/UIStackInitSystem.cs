using Leopotam.Ecs;


public class UIStackInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;

    public void Init()
    {
        EcsEntity entity = ecsWorld.NewEntity();
        ref var component = ref entity.Get<UIStackComponent>();
    }
}
