using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    public ObjectPool pool;
    private void Awake()
    {
        if(pool == null)
        {
            pool = GetComponent<ObjectPool>();
        }
    }

    public void SpawnSphere()
    {
        GameObject obj = pool.GetObject();
                                        // Vector3로 반환되는 프로퍼티, xyz값이 모두 -1~1 사이
        obj.transform.position = Random.insideUnitCircle * 5;
        StartCoroutine(DespawnCoroutine(obj));
    }

    IEnumerator DespawnCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        pool.ReturnObject(obj);
    }
}
