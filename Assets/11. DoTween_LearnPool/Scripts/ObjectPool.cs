using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private Queue<GameObject> pool = new Queue<GameObject>();

    public int startCount = 10; // 시작할 때 생성할 오브젝트 개수

    private void Start()
    {
        for (int i = 0; i < startCount; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);   
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if(pool.Count == 0)
        {
            GameObject obj = Instantiate(prefab, transform);
            pool.Enqueue(obj);
        }

        GameObject @return = pool.Dequeue();
        @return.SetActive(true);
        @return.transform.SetParent(null);
        return @return;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        pool.Enqueue(obj);

    }
}
