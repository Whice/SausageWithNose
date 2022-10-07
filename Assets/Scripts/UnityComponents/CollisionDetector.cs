using Leopotam.Ecs;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private EcsWorld ecsWorld;
    public void Init(EcsWorld ecsWorld)
    {
        this.ecsWorld = ecsWorld;
    }
    private void OnCollisionEnter(Collision collision)
    {
        EcsEntity entity = this.ecsWorld.NewEntity();
        CollisionEventComponent collisionEvent = new CollisionEventComponent();
        collisionEvent.target = collision.gameObject;
        collisionEvent.owner = this.gameObject;
        entity.Replace(collisionEvent);
    }
}
