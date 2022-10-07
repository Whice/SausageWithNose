using Leopotam.Ecs;
using UnityEngine;

public class PlayerJoystickManagmentSystem : IEcsRunSystem
{
    private SceneData sceneData;
    private EcsFilter<PlayerComponent> filter;
    public void Run()
    {
        FixedJoystick joystick = this.sceneData.joystick;
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            float speed;
            foreach (var i in this.filter)
            {
                ref PlayerComponent component = ref this.filter.Get1(i);
                speed = component.speed;

                Vector3 direction = new Vector3(joystick.Horizontal * speed, 0, joystick.Vertical * speed);
                component.transform.rotation = Quaternion.LookRotation(direction);
                component.transform.localPosition += direction * Time.deltaTime;
            }
        }
    }
}
