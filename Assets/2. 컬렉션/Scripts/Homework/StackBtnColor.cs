using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackBtnColor : MonoBehaviour
{
    UseStackRandom useStack;
    void Start()
    {
        useStack = FindAnyObjectByType<UseStackRandom>();
    }

    public void Click_To_ChangeBtn()
    {
        useStack.randoStack.Push(RandomVec());
        useStack.randomColorStack.Push(this.GetComponent<Image>().color);
    }
    Vector3 RandomVec()
    {
        float rand = Random.Range(-1f, 2f);

        Vector3 vec = new Vector3(rand, rand);
        return vec;
    }
}
