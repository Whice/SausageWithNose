using Leopotam.Ecs;
using UnityEngine;

public class PlayerDropViewSystem : IEcsRunSystem
{
    private SceneData sceneData;
    private RuntimeData runtimeData;
    private EcsFilter<LootStackComponent, PlayerComponent> filter;
    public void Run()
    {
        if(this.sceneData.TryPerformDrop())
        {
            ref LootStackComponent stack = ref this.filter.Get1(0);
            int type = 0;
            if (stack.TryPop(ref type))
            {
                ref PlayerComponent player = ref this.filter.Get2(0);
                GameObject go = this.runtimeData.PopLootItemView(type);
                Rigidbody viewRigitbody = go.GetComponent<Rigidbody>();

                go.transform.position = new Vector3
                    (
                    player.transform.position.x,
                    player.transform.position.y+3,
                    player.transform.position.z
                    );

                float force = 5;
                Vector3 directionForce = new Vector3
                (
                    -player.transform.forward.x* force,
                    force,
                    -player.transform.forward.z* force
                );
                viewRigitbody.AddForce(directionForce, ForceMode.Impulse);

            }
        }
    }
}
