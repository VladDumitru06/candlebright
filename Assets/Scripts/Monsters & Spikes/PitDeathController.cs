using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitDeathController : MonoBehaviour
{
    [SerializeField] CharacterDeathController DeathControllerP1;
    [SerializeField] CharacterDeathController DeathControllerP2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
            DeathControllerP1.Death();
        if (collision.tag == "Player2")
            DeathControllerP2.Death();
    }
}
