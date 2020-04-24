using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private CheckpointManager CM;

    private void Start()
    {
        CM = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player1")) //Player1 is found and his checkpoint location is updated
        {
            CM.lastCheckPointPosP1 = transform.position;
        }
        if (collision.CompareTag("Player2"))//Same thing
        {
            CM.lastCheckPointPosP2 = transform.position;
        }
    }

    
}
