using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuTankAnim_sc : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void SetDirectionTrue()
    {
        animator.SetBool("animBool", true);
    }

    public void SetDirectionFalse()
    {
        animator.SetBool("animBool", false);
    }
}
