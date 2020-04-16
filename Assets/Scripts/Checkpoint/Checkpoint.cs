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
        Debug.Log(collision.tag);
        if (collision.CompareTag("Player1"))
        {
            CM.lastCheckPointPosP1 = transform.position;
        }
        if (collision.CompareTag("Player2"))
        {
            CM.lastCheckPointPosP2 = transform.position;
        }
    }

    
}
