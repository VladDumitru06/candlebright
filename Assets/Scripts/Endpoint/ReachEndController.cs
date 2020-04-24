using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachEndController : MonoBehaviour
{
    public bool Player1End;
    public bool Player2End;
    void Start()
    {
        Player1End = false;
        Player2End = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player1End && Player2End)
        {
            Debug.Log("WIN");
        }
    }
}
