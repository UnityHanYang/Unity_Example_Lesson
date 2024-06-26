using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IHitable
{
    public float maxDamage = 10;
    public LayerMask somLayer;

    public void Hit(float damage)
    {
        if(damage >= maxDamage)
        {
            Destroy(gameObject);
        }

        print($"{name} hitted and damaged : {damage}");
    }
}
