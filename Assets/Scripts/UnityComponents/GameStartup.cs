using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class GameStartup : MonoBehaviour
{
    [SerializeField] private StaticData configuration;
    [SerializeField] private SceneData sceneData;

    private EcsWorld ecsWorld;
    private EcsSystems systems;
    void Start()
    {
        this.ecsWorld = new EcsWorld();
        this.systems = new EcsSystems(this.ecsWorld);
        this.sceneData.Init(this.ecsWorld);
        RuntimeData runtimeData = new RuntimeData(this.sceneData, this.configuration);

        this.systems.ConvertScene();

        this.systems
            //init
            .Add(new LootStackInitSystem())
            .Add(new LootGeneratorInitSystem())
            .Add(new UIStackInitSystem())

            //run
            .Add(new PlayerJoystickManagmentSystem())
            .Add(new GenerateLootToStackSystem())
            .Add(new UIStackrunSystem())
            .Add(new PlayerDropViewSystem())
            .Add(new CollisionManagementSystem())

            //destroy
            .Add(new DestroyLootStackSystem())

            //inject
            .Inject(this.configuration)
            .Inject(this.sceneData)
            .Inject(runtimeData)

            //init
            .Init();
    }

    void Update()
    {
        this.systems?.Run();
    }

    private void OnDestroy()
    {
        this.systems?.Destroy();
        this.systems = null;
        this.ecsWorld?.Destroy();
        this.ecsWorld = null;
    }
}
