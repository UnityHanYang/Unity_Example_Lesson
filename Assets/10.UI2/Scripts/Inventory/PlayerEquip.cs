using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour {

    public Transform[] hands;
    private Weapon[] weapons = new Weapon[2];
    private GameObject[] weaponObjs = new GameObject[2];

    public void EquipWeapon(int index, Weapon weapon) {

        if (index > weapons.Length) return;
        
        weapons[index] = weapon;
		
        //�����ϰ� �ִ� �������� �ִٸ�
		if (weaponObjs[index] != null) {
            Destroy(weaponObjs[index]);
            weaponObjs[index] = null;
        }

        //�Ű����� weapon�� null�� �ƴϸ�
        if(weapon != null) { //���� ������Ʈ ����

            //var someWeapon = Instantiate(weapon.equipPrefab);
            //someWeapon.transform.SetParent(hands[index]);
            //someWeapon.transform.localPosition = Vector3.zero;

            weaponObjs[index] = Instantiate(weapon.equipPrefab, hands[index]);
        }
    }
}