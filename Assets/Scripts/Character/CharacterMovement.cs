using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController Controller;
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private Canvas endtext;
    [SerializeField] private int PlayerNr;
    [SerializeField] private Animator Animator;
    [SerializeField] SpiderRope SpiderRope;
    [SerializeField] Animator FireAnimator;
    [SerializeField] CharacterLightController CharacterLight;
    [SerializeField] WaxController WaxController;
    CharacterDeathController DeathController;
    private float movementSpeed;
    private bool jump = false;
    void Start()
    {
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
            if (Input.GetKey(KeyCode.LeftArrow)) // Left
            {
                movementSpeed = playerSpeed * -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow)) // Right
            {
                movementSpeed = playerSpeed;
            }
            else
            {
                movementSpeed = 0;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                jump = true;
            }
            else
            {
                jump = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                WaxController.UseWax();
            }
        }
        
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.localScale.y <= .1f)
        {
            endtext.enabled = true;
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
