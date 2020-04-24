using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstSoundController : MonoBehaviour
{
    // Start is called before the first frame update
    private FMOD.Studio.EventInstance instance;
    [SerializeField] CharacterLightController LightController;
    [FMODUnity.EventRef]
    public string fmodEvent;
    private bool playonlyonce = false;
    private float fade = 0;
    [SerializeField] float fadespeed=10f;
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }
    private void Update()
    {
        if (LightController.IsBursting == true)
        {
            if (playonlyonce == false)
            {
                instance.start();
                playonlyonce = true;
            }
            if ( fade < 100)
            {
                fade = fade + fadespeed * Time.deltaTime;
                Debug.Log(fade);
            }
            instance.setParameterByName("Fade", fade);
        }
        if (LightController.IsBursting == false)
        {
            fade = 0;
            playonlyonce = false;
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

}
