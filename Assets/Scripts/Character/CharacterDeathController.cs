using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Events;

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
    [SerializeField] private WaxController WaxController;
    [SerializeField] private GameObject Flame;
    [SerializeField] private SpiderRope SpiderRope;
    [FMODUnity.EventRef]
    public string DeathSound;
    public UnityEvent HasRespawned;
    private Vector2 Velocity;
    private bool isDead;
    private bool playdeathonlyonce;
    List<ChestController> ChestList;
    public bool IsDead { get { return isDead; } }
    void Start()
    {
        ChestList = new List<ChestController>();
        ChestListpop();
        if (HasRespawned == null)
            HasRespawned = new UnityEvent();
        playdeathonlyonce = false;
        Velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        isDead = false;
    }
    void ChestListpop()
    {
       foreach (GameObject x in GameObject.FindGameObjectsWithTag("Chest"))
        {
            ChestList.Add(x.GetComponent<ChestController>());
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Candle.transform.localScale.y <= 0.1f)
        {
            Death();
        }
        if (Input.GetKey(KeyCode.R) && CharController.PlayerNr == 1)
        {
            Respawn();
        }
        if (Input.GetButton("Respawn") && CharController.PlayerNr == 2)
        {
            Respawn();
        }
    }
    public void Death()
    {
            SpiderRope.DestroyRope();

        if (playdeathonlyonce == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot(DeathSound);
            playdeathonlyonce = true;
        }
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y+1000f);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
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
        if (CharController.PlayerNr == 1)
        {
            foreach (GameObject x in GameObject.FindGameObjectsWithTag("Chest"))
            {
                x.GetComponent<ChestController>().ResetWaxP1();
            }
        }
        if (CharController.PlayerNr == 2)
        {
            foreach (GameObject x in GameObject.FindGameObjectsWithTag("Chest"))
            {
                x.GetComponent<ChestController>().ResetWaxP2();
            }
        }
        playdeathonlyonce = false;
        WaxController.WaxAmount = 0;
        HasRespawned.Invoke();
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        Debug.Log("I RESPAWN");
        Candle.SetActive(true);
        RopeSetter.SetActive(true);
        Flame.SetActive(true);
        CandleCharacter.SetActive(true);
        isDead = false;
        pointlight.transform.localScale = new Vector3(1, Candle.transform.localScale.x, pointlight.transform.localScale.z);
        if (CharController.PlayerNr == 1)
        {
            this.transform.position = CM.lastCheckPointPosP1;
            Candle.transform.localScale = CM.lastCheckPointSizeP1;
        }
        else if (CharController.PlayerNr == 2)
        {
            this.transform.position = CM.lastCheckPointPosP2;
            Candle.transform.localScale = CM.lastCheckPointSizeP2;
        }
    }
}
