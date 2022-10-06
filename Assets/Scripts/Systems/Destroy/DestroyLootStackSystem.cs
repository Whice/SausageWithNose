using Leopotam.Ecs;
using System;

public class DestroyLootStackSystem : IEcsDestroySystem
{
    private EcsFilter<LootStackComponent> filter;
    public void Destroy()
    {
        this.filter.Get1(0).Destroy();
    }
}

