using System.Collections.Generic;
using UnityEngine;

public class RuntimeData
{
    private SceneData sceneData;
    private StaticData staticData;
    private Transform containerDrop;
    public RuntimeData(SceneData sceneData, StaticData staticData)
    {
        this.sceneData = sceneData;
        this.staticData = staticData;
        this.containerDrop = sceneData.GetContainerDrop();
    }
    private Stack<GameObject> lootItemViewPool = new Stack<GameObject>();
    public GameObject PopLootItemView(int type)
    {
        GameObject view = null;
        if (this.lootItemViewPool.Count == 0)
        {
            view = GameObject.Instantiate(this.sceneData.lootItemViewTemplate);
            view.transform.SetParent(this.containerDrop, false);
        }
        else
        {
            view = this.lootItemViewPool.Pop();
        }

        MeshRenderer meshRender = view.GetComponent<MeshRenderer>();
        switch (type)
        {
            case 0:
                {
                    meshRender.material = this.staticData.material0;
                    break;
                }
            case 1:
                {
                    meshRender.material = this.staticData.material1;
                    break;
                }
            case 2:
                {
                    meshRender.material = this.staticData.material2;
                    break;
                }
        }

        return view;
    }
    public void PushLootItemView(GameObject lootItemView)
    {
        this.lootItemViewPool.Push(lootItemView);
    }
}

