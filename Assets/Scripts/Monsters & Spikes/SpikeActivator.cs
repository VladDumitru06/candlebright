using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeActivator : MonoBehaviour
{
    [SerializeField] Animator SpikeAnimator;
    [SerializeField] CharacterDeathController DeathControllerP1;
    [SerializeField] CharacterDeathController DeathControllerP2;
    [FMODUnity.EventRef]
    public string Spikes;


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player1" || collision.tag == "Player2")
        {
            SpikeAnimator.SetBool("Activated", true);

            FMODUnity.RuntimeManager.PlayOneShot(Spikes);
        }

    
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

    if ((collision.tag == "Player1" && DeathControllerP1.IsDead == false) || (collision.tag == "Player2" && DeathControllerP2.IsDead == false))
        SpikeAnimator.SetBool("Activated", true);
        if ((collision.tag == "Player1" && DeathControllerP1.IsDead == true) || (collision.tag == "Player2" && DeathControllerP2.IsDead == true))
            SpikeAnimator.SetBool("Activated", false);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player1" || collision.tag == "Player2")
        {
            FMODUnity.RuntimeManager.PlayOneShot(Spikes);
            SpikeAnimator.SetBool("Activated", false);
        }

    }
}
