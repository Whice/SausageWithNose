using Leopotam.Ecs;


public class LootStackInitSystem : IEcsInitSystem
{
    private StaticData staticData;
    private EcsWorld ecsWorld;
    public void Init()
    {
        EcsEntity stackEntity = ecsWorld.NewEntity();
        ref var component = ref stackEntity.Get<LootStackComponent>();
        component.InitStack(this.staticData.maxStackCapasity);
    }
}
