using System;
using Unity.Collections;
using UnityEngine;

[Serializable]
public struct LootStackComponent
{
    private Int32 lastIndex;
    public Int32 GetLastIndex() => this.lastIndex;
    private Int32 capasityPrivate;
    public Int32 capasity => this.capasityPrivate;

    /// <summary>
    /// Массив компонентов лута.
    /// <br/>Не подлежит изменению извне, только для чтения!
    /// </summary>
    public NativeArray<Int32> lootComponents;

    /// <summary>
    /// Стэк полон.
    /// </summary>
    public bool isFull => this.lastIndex == this.lootComponents.Length;
    public void InitStack(Int32 maxStackCapasity)
    {
        this.lootComponents = new NativeArray<Int32>(maxStackCapasity, Allocator.Persistent);
        this.lastIndex = -1;
        this.capasityPrivate = maxStackCapasity;
    }
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
    public bool TryPush(Int32 component)
    {
        if (this.lastIndex != this.lootComponents.Length - 1)
        {
            ++this.lastIndex;
            this.lootComponents[this.lastIndex] = component;
        }

        return false;
    }

    public void Destroy()
    {
        this.lootComponents.Dispose();
    }
}

