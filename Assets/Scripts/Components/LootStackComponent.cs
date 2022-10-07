using System;
using Unity.Collections;
using UnityEngine;

[Serializable]
public struct LootStackComponent
{
    private Int32 lastIndex;
    public Int32 GetLastIndex() => this.lastIndex;
    public Int32 capasity => this.lootComponents.Length;

    /// <summary>
    /// Массив компонентов лута.
    /// <br/>Не подлежит изменению извне, только для чтения!
    /// </summary>
    public NativeArray<Int32> lootComponents;

    /// <summary>
    /// Стэк полон.
    /// </summary>
    public bool isFull => this.lastIndex == this.capasity-1;
    /// <summary>
    /// Задать вместимость стэка.
    /// </summary>
    /// <param name="maxStackCapasity"></param>
    public void InitStack(Int32 maxStackCapasity)
    {
        this.lootComponents = new NativeArray<Int32>(maxStackCapasity, Allocator.Persistent);
        this.lastIndex = -1;
    }
    /// <summary>
    /// Попытаться вытащить объект типа. Не получиться, если стэк пустой.
    /// </summary>
    /// <param name="componentType"></param>
    /// <returns></returns>
    public bool TryPop(ref Int32 componentType)
    {
        if(this.lastIndex!=-1)
        {
            componentType = this.lootComponents[this.lastIndex];
            --this.lastIndex;
            return true;
        }

        return false;
    }
    /// <summary>
    /// Попытаться запихнуть в стэк лут. Не получиться если стэк полный.
    /// </summary>
    /// <param name="component"></param>
    /// <returns></returns>
    public bool TryPush(Int32 component)
    {
        if (this.lastIndex != this.lootComponents.Length - 1)
        {
            ++this.lastIndex;
            this.lootComponents[this.lastIndex] = component;
        }

        return false;
    }

    /// <summary>
    /// Очистить память для стэка.
    /// </summary>
    public void Destroy()
    {
        this.lootComponents.Dispose();
    }
}

