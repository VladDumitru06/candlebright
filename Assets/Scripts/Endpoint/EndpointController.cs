using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class EndpointController : MonoBehaviour
{
    [SerializeField] Light2D Light; 
    [SerializeField] private int PlayerNr;
    [SerializeField] ReachEndController ReachEnd;
    private bool TriggerExit;
    private void Start()
    {
        TriggerExit = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1" && PlayerNr == 1)
        {
            TriggerExit = false;
            Debug.Log(collision.tag);
            ReachEnd.Player1End = true;
            Light.pointLightOuterRadius = Light.pointLightOuterRadius + 3f*Time.deltaTime;
            Light.intensity = Light.intensity + .3f*Time.deltaTime;
        }
        if (collision.tag == "Player2" && PlayerNr == 2)
        {
            TriggerExit = false;
            ReachEnd.Player2End = true;
            Light.pointLightOuterRadius = Light.pointLightOuterRadius + 3f * Time.deltaTime;
            Light.intensity = Light.intensity + .3f * Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player1" && PlayerNr == 1)
        {
            Debug.Log(collision.tag);
            ReachEnd.Player1End = true;
            if (Light.pointLightOuterRadius <= 7f)
            Light.pointLightOuterRadius = Light.pointLightOuterRadius + 3f * Time.deltaTime;
            if (Light.intensity <= 1.3f)
                Light.intensity = Light.intensity + 3f * Time.deltaTime;
        }
        if (collision.tag == "Player2" && PlayerNr == 2)
        {
            ReachEnd.Player2End = true;
            if (Light.pointLightOuterRadius <= 7f)
                Light.pointLightOuterRadius = Light.pointLightOuterRadius + 3f * Time.deltaTime;
            if (Light.intensity <= 1.3f)
                Light.intensity = Light.intensity + 3f * Time.deltaTime;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player1" && PlayerNr == 1)
        {
            TriggerExit = true;
            ReachEnd.Player1End = false;
            Light.pointLightOuterRadius = Light.pointLightOuterRadius - 3f * Time.deltaTime;
            Light.intensity = Light.intensity - .3f*Time.deltaTime;
        }
        if (collision.tag == "Player2" && PlayerNr == 2)
        {
            TriggerExit = true;
            ReachEnd.Player2End = false;
            Light.pointLightOuterRadius = Light.pointLightOuterRadius - 3f*Time.deltaTime;
            Light.intensity = Light.intensity - .3f*Time.deltaTime;
        }
    }
    private void Update()
    {
        if (TriggerExit == true && Light.pointLightOuterRadius >4f)
        {

            Light.pointLightOuterRadius = Light.pointLightOuterRadius - 3f * Time.deltaTime;

        }
        if(TriggerExit == true && Light.intensity >= 1f)
        {
            Light.intensity = Light.intensity - 3f * Time.deltaTime;
        }
    }
}
