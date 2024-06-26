using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Flags]
public enum Obj_Type
{
    none = 0,
    weapon = 1 << 1,
    expendables = 1 << 2
};

public class UIObjectManager : MonoBehaviour
{
    public static UIObjectManager instance;
    public List<Item> item_List = new List<Item>();
    List<Item> list = new List<Item>();
    public Action<Obj_Type> action;
    public Transform panelParent;
    public GameObject[] objs;

    private void Awake()
    {
        instance = this;
    }

    public void OnClick_Create_Obj()
    {
        int ran = UnityEngine.Random.Range(0, objs.Length);
        GameObject obj = Instantiate(objs[ran], panelParent);
        item_List.Add(obj.GetComponent<Item>());
    }


    public void OnClick_Select_Weapon()
    {
        list.Clear();
        list = item_List.FindAll((param) =>
        {
            return (param.type & Obj_Type.weapon) != 0;
        }
            );
        ChangeAlpha(list);
        action?.Invoke(Obj_Type.weapon);
    }
    public void OnClick_Select_Object()
    {
        list.Clear();
        list = item_List.FindAll((param) =>
        {
            return (param.type & Obj_Type.expendables) != 0;
        }
            );
        ChangeAlpha(list);
        action?.Invoke(Obj_Type.expendables);
    }

    void ChangeAlpha(List<Item> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        }
    }
}
