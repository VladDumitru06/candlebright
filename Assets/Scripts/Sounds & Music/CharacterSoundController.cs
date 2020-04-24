using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundController : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string FootSteps;
    [FMODUnity.EventRef]
    public string Jump;
    [FMODUnity.EventRef]
    public string Burst;
    [FMODUnity.EventRef]
    public string Land;
    //t
    bool playerismoving;
    public float walkingspeed;
    private int playerNr;

    private FMOD.Studio.EventInstance instance;
    [SerializeField] CharacterLightController LightController;
    [SerializeField] SpiderRope SpiderRope;

    private bool playonlyonce = false;
    private bool playjumponlyonce = false;
    private float fade = 0;
    [SerializeField] float fadespeed = 10f;
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(Burst);
        playerNr = gameObject.GetComponent<CharacterController>().playerNr;
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }

    void Update()
    {
        #region BurstSound
        if (LightController.IsBursting == true)
        {
            if (playonlyonce == false)
            {
                instance.start();
                playonlyonce = true;
            }
            if (fade < 100)
            {
                fade = fade + fadespeed * Time.deltaTime;
            }
            instance.setParameterByName("Fade", fade);
        }
        if (LightController.IsBursting == false)
        {
            fade = 0;
            playonlyonce = false;
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        #endregion
        #region StepsSound
        if ((Input.GetAxis("HorizontalMove") > 0.2f || Input.GetAxis("HorizontalMove") < -0.2f) && playerNr == 2 && (Input.GetAxis("VerticalMove") == 0f))
        {
            playerismoving = true;
        }
        else if (Input.GetAxis("HorizontalMove") == 0 && playerNr == 2 || Input.GetAxis("VerticalMove") > 0.2f)
        {

            playerismoving = false;
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && playerNr == 1 && !Input.GetKey(KeyCode.W))
        {
            playerismoving = true;
        }
        else if ((!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D)) && playerNr == 1 || Input.GetKey(KeyCode.W))
        {

            playerismoving = false;
        }
        #endregion
        if (Input.GetAxis("VerticalMove") > 0.2f && playerNr == 2 && gameObject.GetComponent<CharacterController>().IsJumping == false && SpiderRope.Pull == false)
        {

            Debug.Log("jumponce true");
            FMODUnity.RuntimeManager.PlayOneShot(Jump);


        }

        if (Input.GetKey(KeyCode.W)  && playerNr == 1 && gameObject.GetComponent<CharacterController>().IsJumping == false && SpiderRope.Pull == false)
        {
            Debug.Log("PlayJumpingSound");
            FMODUnity.RuntimeManager.PlayOneShot(Jump);

        }


    }
    public void OnLand()
    {
        FMODUnity.RuntimeManager.PlayOneShot(Land);
    }
    void CallFootsteps()
    {
        if (playerismoving == true)
        {
            Debug.Log(playerNr);
            FMODUnity.RuntimeManager.PlayOneShot(FootSteps);
        }
    }
    private void OnDisable()
    {
        playerismoving = false;
    }
}
