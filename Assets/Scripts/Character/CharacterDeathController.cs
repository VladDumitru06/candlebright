using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CharacterDeathController : MonoBehaviour
{
    [SerializeField] private CheckpointManager CM;
    [SerializeField] private Animator Animator;
    [SerializeField] private Animator FireAnimator;
    [SerializeField] private Light2D pointlight;
    [SerializeField] private CharacterController CharController;
    [SerializeField] private GameObject Candle;
    [SerializeField] private GameObject RopeSetter;
    [SerializeField] private GameObject CandleCharacter;
    [SerializeField] private GameObject Flame;
    private Vector2 Velocity;
    private bool isDead;
    public bool IsDead { get { return isDead; } }
    void Start()
    {
        Velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        isDead = false;
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
        Velocity = new Vector2(0f, 0f);
        isDead = true;
        Debug.Log("I DEAD");
        Candle.SetActive(false);
        RopeSetter.SetActive(false);
        Flame.SetActive(false);
        CandleCharacter.SetActive(false);
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
        Velocity = new Vector2(0f, 0f);
        Debug.Log("I RESPAWN");
        Candle.SetActive(true);
        RopeSetter.SetActive(true);
        Flame.SetActive(true);
        CandleCharacter.SetActive(true);
        isDead = false;
        pointlight.transform.localScale = new Vector3(1, pointlight.transform.localScale.y, pointlight.transform.localScale.z);
        Candle.transform.localScale = new Vector3(Candle.transform.localScale.x, 1, Candle.transform.localScale.z);
        if (CharController.PlayerNr == 1)
            this.transform.position = CM.lastCheckPointPosP1;
        else if (CharController.PlayerNr == 2)
            this.transform.position = CM.lastCheckPointPosP2;
    }
}
