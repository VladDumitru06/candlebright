using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeActivator : MonoBehaviour
{
    [SerializeField] Animator SpikeAnimator;
    [SerializeField] CharacterDeathController DeathControllerP1;
    [SerializeField] CharacterDeathController DeathControllerP2;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player1" || collision.tag == "Player2")
            SpikeAnimator.SetBool("Activated",true);

    
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
            SpikeAnimator.SetBool("Activated", false);

    }
}
