using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystickPrivate;
    public FixedJoystick joystick=>this.joystickPrivate;
}
