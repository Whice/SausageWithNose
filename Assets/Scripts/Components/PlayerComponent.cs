using System;
using UnityEngine;

[Serializable]
public struct PlayerComponent
{
    /// <summary>
    /// Скорость игрока.
    /// </summary>
    public float speed;
    public Transform transform;
    public GameObject gameObject;
    public CollisionDetector playerCollisionDetector;
}
