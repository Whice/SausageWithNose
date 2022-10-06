using System;
using Unity.Collections;
using UnityEngine;

[Serializable]
public struct LootStackComponent
{
    private Int32 lastIndex;
    private NativeArray<Int32> lootComponents;
    /// <summary>
    /// Стэк полон.
    /// </summary>
    public bool isFull => this.lastIndex == this.lootComponents.Length;
    public void InitStack(Int32 maxStackCapasity)
    {
        this.lootComponents = new NativeArray<Int32>(maxStackCapasity, Allocator.Persistent);
        this.lastIndex = -1;
    }
    public bool TryPop(Int32 component)
    {
        if(this.lastIndex!=-1)
        {
            component = this.lootComponents[this.lastIndex];
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
            Print();
        }

        return false;
    }
    private void Print()
    {
        string s = "Last index = " + this.lastIndex.ToString() + "\n";
        for(int i=0;i<=this.lastIndex;i++)
        {
            s += this.lootComponents[i].ToString() + "; ";
        }
        Debug.Log(s);
    }
}

