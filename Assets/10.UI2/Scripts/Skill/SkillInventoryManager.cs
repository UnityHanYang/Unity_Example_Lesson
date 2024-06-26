using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventoryManager : MonoBehaviour
{
    public static SkillInventoryManager Instance { get; private set; }
    public Transform skillPage;

    public Transform content;

    public SkillInventorySlot selectedSlot;
    public SkillInventorySlot focusedSlot;

    public List<Skill> skillList;
    public List<AttackSkill> attackSkillList;

    private void Awake()
    {
        Instance = this;

        for(int i = 0;i< skillList.Count; i++)
        {
            content.GetChild(i).GetComponent<SkillInventorySlot>().Skill_P = skillList[i];
        }
    }
}


[Serializable]
public class Skill
{
    public Sprite iconSprite;
    public string name;
    public string desc;
}

[Serializable]
public class AttackSkill : Skill
{
    public float damage;
    public GameObject skillPrefab;
}
