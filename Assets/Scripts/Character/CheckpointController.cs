using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private CheckpointManager Cm;
    [SerializeField] private int PlayerNr;
    void Start()
    {
        Cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //Death
        {
            if(PlayerNr == 1)
            this.transform.position = Cm.lastCheckPointPosP1;
            if (PlayerNr == 2)
                this.transform.position = Cm.lastCheckPointPosP2;
        }
    }
}
