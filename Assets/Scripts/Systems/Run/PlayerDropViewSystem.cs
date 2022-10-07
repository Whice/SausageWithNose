using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropViewSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private SceneData sceneData;
    private RuntimeData runtimeData;
    private EcsFilter<LootStackComponent, PlayerComponent> filter;
    private EcsFilter<LootComponent> lootFilter;
    private struct GameObjectWithType
    {
        public GameObject gameObject;
        public int type;
    }
    private Stack<GameObjectWithType> gameObjectsWithType = new Stack<GameObjectWithType>();
    public void Run()
    {
        //Указать для новосозданных LootComponent их тип,
        //имея созданные для определенного типа gameObject'ы
        while (this.gameObjectsWithType.Count != 0)
        {
            GameObjectWithType goWithType = this.gameObjectsWithType.Pop();
            GameObject lootView = goWithType.gameObject;
            int type = goWithType.type;
            //указать тип для лут-компонента
            foreach (int i in this.lootFilter)
            {
                ref LootComponent loot = ref this.lootFilter.Get1(i);
                if (loot.gameObject == lootView)
                {
                    loot.type = type;
                    break;
                }
            }
            
        }

        //Создать новый view указанного типа, если уже можно.
        if (this.sceneData.TryPerformDrop())
        {
            ref LootStackComponent stack = ref this.filter.Get1(0);
            int type = 0;

            //Если есть, что выбросить
            if (stack.TryPop(ref type))
            {
                //получить данные игрока, чтоыб выкинуть около него
                ref PlayerComponent player = ref this.filter.Get2(0);

                //Получить данные лута
                GameObject lootView = this.runtimeData.PopLootItemView(type);
                Rigidbody viewRigitbody = lootView.GetComponent<Rigidbody>();

                //задать позицию
                lootView.transform.position = new Vector3
                    (
                    player.transform.position.x,
                    player.transform.position.y+3,
                    player.transform.position.z
                    );


                GameObjectWithType goWithType = new GameObjectWithType();
                goWithType.gameObject = lootView;
                goWithType.type = type;
                this.gameObjectsWithType.Push(goWithType);
               

                //выкинуть применив силу
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
