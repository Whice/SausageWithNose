using System;
using UnityEngine;

[CreateAssetMenu]
public class StaticData : ScriptableObject
{
    /// <summary>
    /// Максимальный размер стека.
    /// </summary>
    public Int32 maxStackCapasity;
    /// <summary>
    /// Время, раз в которое генерируется новый объект.
    /// </summary>
    public float generateTime;
    public Material material0;
    public Material material1;
    public Material material2;
}
