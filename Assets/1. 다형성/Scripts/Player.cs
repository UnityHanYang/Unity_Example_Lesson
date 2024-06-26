using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHitable
{
    public Bullet bulletPrefab;
    public Transform shotPoint;

    public float damage = 10;

    public float maxHp;
    public float currentHp;
    public void Hit(float mamage)
    {
        currentHp -= damage;
        print($"Player take damage : {damage}, current hp: {currentHp}");
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    public void Shot()
    {
        Bullet bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10f, ForceMode.Impulse);

        bullet.damage = damage;
        // bullet에게 맞아야 할 대상의 Layer 지정
        bullet.targetLayer = (1 << LayerMask.NameToLayer("Box")) | (1 << LayerMask.NameToLayer("Monster"));
        //bullet.targetLayer = ((1 << LayerMask.NameToLayer("Monster")));

        Destroy(bullet, 3f);
    }
}
