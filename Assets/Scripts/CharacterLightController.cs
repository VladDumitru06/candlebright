using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CharacterLightController : MonoBehaviour
{
    [SerializeField] private float resizeSpeed = .01f;
    [SerializeField] private Transform light;
    [SerializeField] private Light2D pointlight;
    [SerializeField] private Transform lightPosition;
    [SerializeField] private Canvas endtext;
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
        if (Input.GetKey(KeyCode.Space) && this.transform.localScale.y >= .1f)
        {
            pointlight.transform.localScale = new Vector3(2f, 2f, 2f);
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y - resizeSpeed, this.transform.localScale.z);

        }
        else
        {
            light.localScale = new Vector3(this.transform.localScale.y, this.transform.localScale.y, light.localScale.z);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.position = new Vector3(-5, 1, this.transform.position.z);
            endtext.enabled = false;
            light.localScale = new Vector3(1, light.localScale.y, light.localScale.z);
            this.transform.localScale = new Vector3(this.transform.localScale.x, 1, this.transform.localScale.z);
        }
        if (this.transform.localScale.y <= .1f)
        {
            
        }

    }
}
