using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Obj_Type type;
    private Image currentC;
    private Action<Obj_Type> actionHandler;


    void Start()
    {
        currentC = this.GetComponent<Image>();
        actionHandler += (obj_type) =>
        {
            if ((type & obj_type) == 0)
                {
                    currentC.color = new Color(1, 1, 1, 0.5f);
                }
            };
        UIObjectManager.instance.action += actionHandler;
    }
    
    public void Click_Remove()
    {
        if(actionHandler != null)
        {
            UIObjectManager.instance.action -= actionHandler;
        }
        UIObjectManager.instance.item_List.Remove(this.gameObject.GetComponent<Item>());
        Destroy(this.gameObject);
    }
}
