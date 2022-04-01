using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel_Action : MonoBehaviour, Action
{
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void getAtacked() {
        animator.SetTrigger("isGetAttacked");
    }

    public void adjustAlphaValue(float value)
    {
    }

    
}
