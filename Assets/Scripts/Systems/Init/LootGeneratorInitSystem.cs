using Leopotam.Ecs;


public class LootGeneratorInitSystem : IEcsInitSystem
{
    private StaticData staticData;
    private EcsWorld ecsWorld;

    public void Init()
    {
        EcsEntity generatorEntity = ecsWorld.NewEntity();
        ref var component = ref generatorEntity.Get<LootGeneratorComponent>();
        component.generateTime = this.staticData.generateTime;
        component.leftTime = 0;
    }
}
