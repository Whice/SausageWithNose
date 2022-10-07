using System;
using UnityEngine;

[Serializable]
public struct LootComponent
{
    /// <summary>
    /// Тип генерируемого объекта.
    /// <br/>0 - красный.
    /// <br/>1 - желтый.
    /// <br/>2 - синий.
    /// </summary>
    public Int32 type;
    /// <summary>
    /// Игровой объект этого компонента.
    /// </summary>
    public GameObject gameObject;
}
