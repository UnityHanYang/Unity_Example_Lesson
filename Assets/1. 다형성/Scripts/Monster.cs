using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public string monsterName;
    public float maxHp;
    public float currenteHp;

    public float damage;

    public GameObject bulletPrefab; // bullet ������
    public Transform shotPoint; // �ѱ� (bullet�� ������ ��ġ�� �����ϱ� ���� gameobject)

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
        // bullet ����
        GameObject bulletObject = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        // rigidbody ���� �� Addforce�� ���� ������ ���󰡵��� ��
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * 10f, ForceMode.Impulse);

        // bullet ���� �� ������ �Ҵ�
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.damage = damage;
        bullet.targetLayer = 1 << LayerMask.NameToLayer("Player");


        // 3�� �Ŀ� ����������.
        Destroy(bullet, 3f);
    }
}
