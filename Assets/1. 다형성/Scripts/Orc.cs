using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Monster, IHitable
{
    public string orcPassive = "��ũ�� �������� 10% �� �޽��ϴ�";
    void Start()
    {
        maxHp = currenteHp = 150;
    }

    public override void Hit(float damage)
    {
        damage *= .9f;

        base.Hit(damage);
    }
}
