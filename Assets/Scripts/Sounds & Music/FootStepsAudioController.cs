using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsAudioController : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputsound;
    bool playerismoving;
    public float walkingspeed;
    private int playerNr;

    private void Start()
    {
        playerNr = gameObject.GetComponent<CharacterController>().playerNr;
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }
    private void Update()
    {
        if((Input.GetAxis("HorizontalMove") > 0.2f || Input.GetAxis("HorizontalMove") < -0.2f) && playerNr == 2)
        {
            playerismoving = true;
        }
        else if (Input.GetAxis("HorizontalMove") == 0 && playerNr == 2)
        {

            playerismoving = false;
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && playerNr == 1)
        {
            playerismoving = true;
        }
        else if ((!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D)) && playerNr == 1)
        {

            playerismoving = false;
        }
    }
    void CallFootsteps ()
    {
        if(playerismoving == true)
        {
            Debug.Log(playerNr);
            FMODUnity.RuntimeManager.PlayOneShot (inputsound);
        }
    }
    private void OnDisable()
    {
        playerismoving = false;
    }

}
