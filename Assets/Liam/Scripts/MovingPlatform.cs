using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Animator animator;


    private void Start()
    {
        
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        animator.SetTrigger("MoveForward");

        yield return new WaitForSeconds(10f);
        
        animator.SetTrigger("MoveBackwards");
        
        yield return new WaitForSeconds(10f);


        StartCoroutine(MoveObject());
    }
}
