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
                                        // Vector3�� ��ȯ�Ǵ� ������Ƽ, xyz���� ��� -1~1 ����
        obj.transform.position = Random.insideUnitCircle * 5;
        StartCoroutine(DespawnCoroutine(obj));
    }

    IEnumerator DespawnCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        pool.ReturnObject(obj);
    }
}
