using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IObject
{
    private Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    public void Trigger_Event()
    {
        animator.SetBool("Open", true); 
    }

    public void Close_Event()
    {
        animator.SetBool("Open", false);
    }
}
