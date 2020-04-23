using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] CharacterDeathController DeathControllerP1;
    [SerializeField] CharacterDeathController DeathControllerP2;
    
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
            DeathControllerP1.Death();
        if (collision.tag == "Player2")
            DeathControllerP2.Death();

    }

   
}
