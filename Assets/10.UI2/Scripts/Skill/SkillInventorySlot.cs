using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillInventorySlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image iconImage;
    internal Skill skill = null;

    public Skill Skill_P
    {
        get { return skill; }
        set
        {
            skill = value;
            if (skill != null)
            {
                iconImage.enabled = true;
                iconImage.sprite = skill.iconSprite;
            }
            else
            {
                iconImage.enabled = false;
            }
        }
    }

    private void Start()
    {
        Skill_P = this.skill;
    }

    public bool TrySwap(Skill skill)
    {
        if (skill is Skill && hasItem)
        {
            if (this.skill is Skill)
            {
                return true;
            }
            else return false;
        }
        return true;
    }
    public bool hasItem { get { return skill != null; } }
    public void OnDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            return;
        }

        iconImage.rectTransform.position = data.position;

    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            return;
        }
        iconImage.rectTransform.SetParent(SkillInventoryManager.Instance.skillPage);

        SkillInventoryManager.Instance.selectedSlot = this;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            return;
        }
        if (SkillInventoryManager.Instance.focusedSlot != this && SkillInventoryManager.Instance.focusedSlot != null)
        {
            SkillInventorySlot targetSlot = SkillInventoryManager.Instance.focusedSlot;
            if (targetSlot.TrySwap(skill))
            {
                Skill tempItem = targetSlot.Skill_P;
                targetSlot.Skill_P = skill;
                this.Skill_P = tempItem;
                this.skill = tempItem;
            }
        }

        SkillInventoryManager.Instance.selectedSlot = null;

        iconImage.rectTransform.SetParent(transform);
        iconImage.rectTransform.anchoredPosition = Vector2.zero;

    }
    private void Update()
    {
        print(SkillInventoryManager.Instance.focusedSlot);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillInventoryManager.Instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SkillInventoryManager.Instance.focusedSlot = null;
    }
}
