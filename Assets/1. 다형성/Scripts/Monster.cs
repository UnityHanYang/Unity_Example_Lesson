using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public string monsterName;
    public float maxHp;
    public float currenteHp;

    public float damage;

    public GameObject bulletPrefab; // bullet 프리팹
    public Transform shotPoint; // 총구 (bullet을 생성할 위치에 참조하기 위한 gameobject)

    public float shotInterval = 1;

    void Start()
    {
        //StartCoroutine("ShotCoroutine");
    }
    public virtual void Hit(float damage)
    {
        currenteHp -= damage;

        print($"{name} Take Damage : {damage}, current Hp : {currenteHp}");
    }


    IEnumerator ShotCoroutine()
    {
        if (bulletPrefab == null || shotPoint == null)
            yield return null;

        while (true)
        {
            Shot();

            yield return new WaitForSeconds(shotInterval);
        }
    }

    public void Shot()
    {
        // bullet 생성
        GameObject bulletObject = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        // rigidbody 참조 및 Addforce를 통해 앞으로 날라가도록 함
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * 10f, ForceMode.Impulse);

        // bullet 참조 및 데미지 할당
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.damage = damage;
        bullet.targetLayer = 1 << LayerMask.NameToLayer("Player");


        // 3초 후에 없어지세요.
        Destroy(bullet, 3f);
    }
}
