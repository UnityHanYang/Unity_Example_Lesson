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

        // ���� �ڵ� (ȸ�翡�� �̷��� ¥����, interface ���)
        if (other.TryGetComponent<IHitable>(out var hitable))
        {
            hitable.Hit(damage);
        }

        // Ÿ�̹� ������ �� ��(1�� ����) ���
        //other.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);

        Destroy(gameObject);        
    }
}
