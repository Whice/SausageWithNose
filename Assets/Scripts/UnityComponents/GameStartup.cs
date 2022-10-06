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
            .Add(new PlayerInitSystem())
            .Add(new PlayerJoystickManagmentSystem())
            .Inject(this.configuration)
            .Inject(this.sceneData)
            .Inject(runtimeData)
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
