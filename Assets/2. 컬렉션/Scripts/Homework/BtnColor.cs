using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnColor : MonoBehaviour
{
    UseQueueRandom useQ;
    void Start()
    {
        useQ = FindAnyObjectByType<UseQueueRandom>();
    }

    public void Click_To_ChangeBtn()
    {
        useQ.randoQueue.Enqueue(RandomVec());
        useQ.randomColorQueue.Enqueue(this.GetComponent<Image>().color);
    }
    Vector3 RandomVec()
    {
        float rand = Random.Range(-1f, 2f);

        Vector3 vec = new Vector3(rand, rand);
        return vec;
    }
}
