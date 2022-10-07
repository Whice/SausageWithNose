using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManagementSystem : IEcsRunSystem
{
    private SceneData sceneData;
    private RuntimeData runtimeData;
    private EcsFilter<CollisionEventComponent> collisionFilter;
    private EcsFilter<PlayerComponent> playerFilter;
    private EcsFilter<LootComponent> lootFilter;
    private EcsFilter<LootStackComponent> lootStackFilter;

    public void Run()
    {
        ref PlayerComponent player = ref this.playerFilter.Get1(0);
        ref LootStackComponent stack = ref this.lootStackFilter.Get1(0);

        foreach (int i in this.collisionFilter)
        {
            ref CollisionEventComponent eventComponent = ref this.collisionFilter.Get1(i);
            if (eventComponent.owner == player.gameObject)//Только если хозяин коллизии - игрок
            {
                ref var eventEntity = ref this.collisionFilter.GetEntity(i);
                foreach (int j in this.lootFilter)
                {
                    ref LootComponent loot = ref this.lootFilter.Get1(j);
                    if (eventComponent.target == loot.gameObject)//Только если игрок столнкулся с лут-объектом
                    {
                        if (!stack.isFull)
                        {
                            stack.TryPush(loot.type);
                            this.runtimeData.PushLootItemView(loot.gameObject);
                        }
                    }
                }
                eventEntity.Del<CollisionEventComponent>();
            }
        }
    }
}