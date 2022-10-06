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
        RuntimeData runtimeData = new RuntimeData();

        this.systems.ConvertScene();

        this.systems
            //init
            .Add(new PlayerInitSystem())
            .Add(new LootStackInitSystem())
            .Add(new LootGeneratorInitSystem())

            //run
            .Add(new PlayerJoystickManagmentSystem())
            .Add(new GenerateLootToStackSystem())

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
