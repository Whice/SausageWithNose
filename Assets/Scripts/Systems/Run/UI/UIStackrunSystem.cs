using Leopotam.Ecs;
using System;
using UnityEngine;

public class UIStackrunSystem : IEcsRunSystem
{
    private EcsFilter<LootStackComponent, UIStackComponent> filter;
    public void Run()
    {
        ref LootStackComponent stack = ref this.filter.Get1(0);
        ref UIStackComponent UIStack = ref this.filter.Get2(0);

        UIStack.ClearUI();

        Int32 end = stack.GetLastIndex()+1;
        for (Int32 i = 0; i < end; i++)
        {
            UIStack.AddLootItem(stack.lootComponents[i]);
        }
    }
}
