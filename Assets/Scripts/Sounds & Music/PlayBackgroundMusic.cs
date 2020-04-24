using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{


    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/BackgroundSound", gameObject);

    }



}
