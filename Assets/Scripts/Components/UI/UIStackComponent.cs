using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct UIStackComponent
{
    public GameObject lootItem;
    public Transform parentTransform;

    private Stack<GameObject> pool;
    private Stack<GameObject> visibleLootItems;
    private GameObject GetLookItem()
    {
        if (this.pool == null)
            this.pool = new Stack<GameObject>();

        GameObject lootItem = null;
        if (this.pool.Count == 0)
        {
            lootItem = GameObject.Instantiate(this.lootItem);
        }
        else
        {
            lootItem = this.pool.Pop();
        }

        return lootItem;
    }
    public void AddLootItem(int type)
    {
        GameObject item = GetLookItem();
        Image image = item.GetComponent<Image>();
        switch (type)
        {
            case 0:
                {
                    image.color = Color.red;
                    break;
                }
            case 1:
                {
                    image.color = Color.yellow;
                    break;
                }
            case 2:
                {
                    image.color = Color.blue;
                    break;
                }
        }
        item.transform.SetParent(this.parentTransform, false);
        this.visibleLootItems.Push(item);
    }
    public void ClearUI()
    {
        if (this.visibleLootItems == null)
            this.visibleLootItems = new Stack<GameObject>();
        while (this.visibleLootItems.Count != 0)
        {
            this.pool.Push(this.visibleLootItems.Pop());
        }
    }
}
