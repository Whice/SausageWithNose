using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystickPrivate = null;
    public FixedJoystick joystick=>this.joystickPrivate;


    #region drop

    [Header("Drop")]
    [SerializeField] private GameObject lootItemViewTemplatePrivate = null;
    public GameObject lootItemViewTemplate => this.lootItemViewTemplatePrivate;
    [SerializeField] private Transform containerForDrop;
    public Transform GetContainerDrop()
    {
        return this.containerForDrop;
    }

    [SerializeField] private float delayForDrop;
    private float timeThisDrop;
    private float lastTimeDrop = 0;
    private bool isNeedDrop=false;
    /// <summary>
    /// Указать, что нужно выбросить один view у игрока.
    /// </summary>
    public void CreateDrop()
    {
        this.timeThisDrop = Time.time;
        if ((this.timeThisDrop-this.lastTimeDrop) > this.delayForDrop)
        {
            this.lastTimeDrop = this.timeThisDrop;
            this.isNeedDrop = true;
        }
    }
    /// <summary>
    /// Попытаться выбросить view.
    /// </summary>
    /// <returns></returns>
    public bool TryPerformDrop()
    {
        if(this.isNeedDrop)
        {
            this.isNeedDrop = false;
            return true;
        }
        return false;
    }

    #endregion drop
}
