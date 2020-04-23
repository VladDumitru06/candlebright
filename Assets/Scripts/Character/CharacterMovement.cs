using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController Controller;
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private int PlayerNr;
    [SerializeField] private Animator Animator;
    [SerializeField] SpiderRope SpiderRope;
    [SerializeField] Animator FireAnimator;
    [SerializeField] CharacterLightController CharacterLight;
    [SerializeField] WaxController WaxController;
    CharacterDeathController DeathController;
    private float movementSpeed;
    private bool jump = false;
    private bool CanUseWax;
    void Start()
    {
        CanUseWax = true;
        DeathController = GetComponent<CharacterDeathController>();
        Controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (PlayerNr == 1)
        { 
            if (Input.GetKey(KeyCode.A)) // Left
            {

                movementSpeed = playerSpeed * -1;
            }
            else if (Input.GetKey(KeyCode.D)) // Right
            {

                movementSpeed = playerSpeed;
            }
            else if (!Input.GetKey(KeyCode.W))
            {

                movementSpeed = 0;
            }

            if (Input.GetKey(KeyCode.W))
            {

                jump = true;
            }
            else
            {
                jump = false;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                WaxController.UseWax();
            }
        }
        else if(PlayerNr == 2)
                {
          //  Debug.Log(Input.GetAxis("VerticalMove") + " " + Input.GetAxis("HorizontalMove") + " " + Input.GetButton("UseWax") + " " + Input.GetAxis("Burst") + " " + Input.GetAxis("ShootHook"));

            if (Input.GetAxis("HorizontalMove") > 0.2 || Input.GetAxis("HorizontalMove") < -0.2) // Left
            {
                movementSpeed = playerSpeed * Input.GetAxis("HorizontalMove");
            }
            else
            {
                movementSpeed = 0;
            }

            if (Input.GetAxis("VerticalMove") > 0.2 )
            {

                jump = true;
            }
            else
            {
                jump = false;
            }
            if (Input.GetButton("UseWax") && CanUseWax == true)
            {
                WaxController.UseWax();
                CanUseWax = false;
            }
            if (!Input.GetButton("UseWax") && CanUseWax == false)
            {
                CanUseWax = true;
            }

        }
        
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.localScale.y <= .1f)
        {
            //endtext.enabled = true;
        }
        else
        {

            //Check if the player is running
            if (movementSpeed != 0 && jump == false && Controller.M_Grounded == true)
            {
                //Fire
                FireAnimator.SetBool("IsBursting", false);
                FireAnimator.SetBool("IsRunning", true);
                FireAnimator.SetBool("IsJumping", false);
                FireAnimator.SetBool("IsIdle", false);

                //Body
                Animator.SetBool("IsRunning", true);
                Animator.SetBool("IsIdle", false);
                Animator.SetBool("IsJumping", false);
                Animator.SetBool("IsSwinging", false);
            }
            //Check if the player is jumping/if the player is in the air
            else if ((jump == true) || (movementSpeed == 0 && Controller.M_Grounded == false && SpiderRope.IsSwinging == false))
            {
                //Fire
                FireAnimator.SetBool("IsBursting", false);
                FireAnimator.SetBool("IsRunning", false);
                FireAnimator.SetBool("IsJumping", true);
                FireAnimator.SetBool("IsIdle", false);

                //Body
                Animator.SetBool("IsRunning", false);
                Animator.SetBool("IsIdle", false);
                Animator.SetBool("IsJumping", true);
                Animator.SetBool("IsSwinging", false);
            }
            //check if the player is idle on the ground
            if(movementSpeed == 0 && jump == false && Controller.M_Grounded == true && SpiderRope.IsSwinging == false)
            {
                //Fire
                FireAnimator.SetBool("IsBursting", false);
                FireAnimator.SetBool("IsRunning", false);
                FireAnimator.SetBool("IsJumping", false);
                FireAnimator.SetBool("IsIdle", true);

                //Body
                Animator.SetBool("IsRunning", false);
                Animator.SetBool("IsIdle", true);
                Animator.SetBool("IsJumping", false);
                Animator.SetBool("IsSwinging", false);
            }
            //Check if the player is swinging
            if(SpiderRope.IsSwinging == true)
            {
                //Fire
                FireAnimator.SetBool("IsBursting", false);
                FireAnimator.SetBool("IsRunning", false);
                FireAnimator.SetBool("IsJumping", true);
                FireAnimator.SetBool("IsIdle", false);

                //Body
                Animator.SetBool("IsRunning", false);
                Animator.SetBool("IsIdle", false);
                Animator.SetBool("IsJumping", false);
                Animator.SetBool("IsSwinging", true);
            }
            if(CharacterLight.IsBursting == true)
            {                
                //Fire
                FireAnimator.SetBool("IsBursting", true);
                FireAnimator.SetBool("IsRunning", false);
                FireAnimator.SetBool("IsJumping", false);
                FireAnimator.SetBool("IsIdle", false);

            }
            if(DeathController.IsDead == false)
                Controller.Move(movementSpeed, false, jump,PlayerNr);
        }
    }
}
