using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1 : MonoBehaviour, IObject
{
    public TriggerObject to;
    private Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        to = FindAnyObjectByType<TriggerObject>();
    }

    public void Trigger_Event()
    {
        animator?.SetTrigger("FadeIn");
    }

    public void BoxDestroy()
    {
        to.text.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
