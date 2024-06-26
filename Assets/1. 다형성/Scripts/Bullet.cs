using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public LayerMask targetLayer;

    void OnTriggerEnter(Collider other)
    {
        if (((targetLayer) | (1 << other.gameObject.layer)) != targetLayer)
        {
            return;
        }

        // 정석 코드 (회사에선 이렇게 짜야함, interface 사용)
        if (other.TryGetComponent<IHitable>(out var hitable))
        {
            hitable.Hit(damage);
        }

        // 타이밍 빠르게 할 때(1인 개발) 사용
        //other.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);

        Destroy(gameObject);        
    }
}
