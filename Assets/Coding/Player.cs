using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movement;
    public SpriteRenderer sr;
    public Animator animator;
    
void Update()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(movement * 0.1f, 0f, 0f);
        if(movement < 0)
        {
            sr.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            sr.flipX = false;
            animator.SetBool("Run", true);
        };
        if(movement == 0)
        {
            animator.SetBool("Run", false);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(runTime());
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(ThrowTime());
        }
    }
    IEnumerator runTime()
    {
        animator.SetBool("Jump", true);
        transform.position = transform.position + new Vector3(0f, 1.5f, 0f);
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("Jump", false);
    }
    IEnumerator ThrowTime()
    {
        animator.SetBool("Throw", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Throw", false);
    }
}
