using System;
using UnityEngine;

[Serializable]
public struct PlayerComponent
{
    /// <summary>
    /// �������� ������.
    /// </summary>
    public float speed;
    public Transform transform;
    public GameObject gameObject;
    public CollisionDetector playerCollisionDetector;
}
