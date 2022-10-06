using Leopotam.Ecs;
using UnityEngine;

public class GenerateLootToStackSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private SceneData sceneData;
    private EcsFilter<LootGeneratorComponent, LootStackComponent> filter;
    public void Run()
    {
        ref LootGeneratorComponent generator = ref this.filter.Get1(0);
        generator.leftTime += Time.deltaTime;
        if (generator.leftTime > generator.generateTime)
        {
            generator.leftTime -= generator.generateTime;

            ref LootStackComponent stack = ref this.filter.Get2(0);
            int type = Random.Range(0, 3);
            if(!stack.isFull)
                stack.TryPush(type);
        }
    }
}