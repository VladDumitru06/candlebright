using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] Animator Animator;
    [SerializeField] Animator FireAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Press()
    {
        //Fire
        FireAnimator.SetBool("IsBursting", false);
        FireAnimator.SetBool("IsRunning", false);
        FireAnimator.SetBool("IsJumping", false);
        FireAnimator.SetBool("IsIdle", true);

        //Body
        Animator.SetBool("IsIdle", true);
        Animator.SetBool("IsRunning", false);
        Animator.SetBool("IsJumping", false);
        Animator.SetBool("IsSwinging", false);
    }
    void Update()
    {
        
    }
}
