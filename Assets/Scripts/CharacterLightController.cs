using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CharacterLightController : MonoBehaviour
{
    [SerializeField] private float resizeSpeed = .01f;
    [SerializeField] private Light2D pointlight;
    [SerializeField] private Transform lightPosition;
    [SerializeField] private Canvas endtext;
    [SerializeField] private CharacterController CharacterController;
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        pointlight.transform.position = lightPosition.transform.position;
    }
    void FixedUpdate()
    {
        if (CharacterController.PlayerNr == 1)
        { 
        if (Input.GetKey(KeyCode.E) && this.transform.localScale.y >= .1f)
        {
            pointlight.transform.localScale = new Vector3(2f,  (2f / this.transform.localScale.y));
                Debug.Log("Point " + pointlight.transform.localScale.y);
               // light.transform.localScale = new Vector3(this.transform.localScale.y, 1, this.light.transform.localScale.z);
                this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y - resizeSpeed, this.transform.localScale.z);

        }
        else
        {
                pointlight.transform.localScale = new Vector3(this.transform.localScale.y, 1, this.pointlight.transform.localScale.z);
        }
        if (Input.GetKey(KeyCode.R))
        {
            this.transform.position = new Vector3(-5, 1, this.transform.position.z);
            endtext.enabled = false;
                pointlight.transform.localScale = new Vector3(1, pointlight.transform.localScale.y, pointlight.transform.localScale.z);
            this.transform.localScale = new Vector3(this.transform.localScale.x, 1, this.transform.localScale.z);
        }
        if (this.transform.localScale.y <= .1f)
        {
            
        }
        }
        if (CharacterController.PlayerNr == 2)
        {
            if (Input.GetKey(KeyCode.Space) && this.transform.localScale.y >= .1f)
            {
                pointlight.transform.localScale = new Vector3(2f, (2f / this.transform.localScale.y));
                Debug.Log("Point " + pointlight.transform.localScale.y);
                // light.transform.localScale = new Vector3(this.transform.localScale.y, 1, this.light.transform.localScale.z);
                this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y - resizeSpeed, this.transform.localScale.z);

            }
            else
            {
                pointlight.transform.localScale = new Vector3(this.transform.localScale.y, 1, this.pointlight.transform.localScale.z);
            }
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                this.transform.position = new Vector3(-5, 1, this.transform.position.z);
                endtext.enabled = false;
                pointlight.transform.localScale = new Vector3(1, pointlight.transform.localScale.y, pointlight.transform.localScale.z);
                this.transform.localScale = new Vector3(this.transform.localScale.x, 1, this.transform.localScale.z);
            }
            if (this.transform.localScale.y <= .1f)
            {

            }
        }
    }
}
