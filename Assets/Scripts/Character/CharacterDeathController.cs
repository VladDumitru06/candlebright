using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CharacterDeathController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private CheckpointManager CM;
    [SerializeField] private Animator Animator;
    [SerializeField] private Animator FireAnimator;
    [SerializeField] private Light2D pointlight;
    [SerializeField] private CharacterController CharController;
    [SerializeField] private GameObject Candle;
    private bool IsDead;
    void Start()
    {
        IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Candle.transform.localScale.y <= 0.1f)
        {
            Death();
        }
        if (Input.GetKey(KeyCode.R))
        {
            Respawn();
        }
    }
    void Death()
    {
        IsDead = true;
        Debug.Log("I DEAD");
        Candle.SetActive(false);
        //Fire
        FireAnimator.SetBool("IsBursting", false);
        FireAnimator.SetBool("IsRunning", false);
        FireAnimator.SetBool("IsJumping", false);
        FireAnimator.SetBool("IsIdle", false);

        //Body
        Animator.SetBool("IsRunning", false);
        Animator.SetBool("IsIdle", false);
        Animator.SetBool("IsJumping", false);
        Animator.SetBool("IsSwinging", false);


    }
    void Respawn()
    {

        Debug.Log("I RESPAWN");
        Candle.SetActive(true);
        IsDead = false;
        pointlight.transform.localScale = new Vector3(1, pointlight.transform.localScale.y, pointlight.transform.localScale.z);
        Candle.transform.localScale = new Vector3(Candle.transform.localScale.x, 1, Candle.transform.localScale.z);
        if (CharController.PlayerNr == 1)
            this.transform.position = CM.lastCheckPointPosP1;
        else if (CharController.PlayerNr == 2)
            this.transform.position = CM.lastCheckPointPosP2;
    }
}
