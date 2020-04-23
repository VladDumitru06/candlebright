using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CharacterLightController : MonoBehaviour
{
    [SerializeField] private float lightresizeSpeed = 20f;
    [SerializeField] private Light2D pointlight;
    [SerializeField] private Transform lightPosition;
    [SerializeField] private Canvas endtext;
    [SerializeField] private CharacterController CharacterController;
    [SerializeField] private GameObject CharacterAnimated;
    [SerializeField] private GameObject Candle;
    [SerializeField] private float resizeSeconds = 10f;
    private GameObject Candle_FullSize; // using the transform values for calculating the resize speed
    private bool isBursting;
    private float resizeTimer = 0f;
    private float resizePerFrameValue;

    public bool IsBursting { get { return isBursting; } }
    void Start()
    {
        Candle_FullSize = Candle;
        //The value that the candle has to be resized by. 
        resizePerFrameValue = (9 * Candle_FullSize.transform.localScale.y) / (10 * resizeSeconds * 50);
        isBursting = false;
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
            if (Input.GetKey(KeyCode.E) && Candle.transform.localScale.y >= .1f)
            {
                //pointlight.transform.localScale = new Vector3(2f, (2f / Candle.transform.localScale.y));
                isBursting = true;
                //light scale
                if (pointlight.transform.localScale.x < 2f)
                    pointlight.transform.localScale = new Vector3(pointlight.transform.localScale.x + lightresizeSpeed* Time.deltaTime, pointlight.transform.localScale.y);

                if (pointlight.transform.localScale.y < (2f / Candle.transform.localScale.y))
                    pointlight.transform.localScale = new Vector3(pointlight.transform.localScale.x, pointlight.transform.localScale.y + ((lightresizeSpeed/Candle.transform.localScale.y) * Time.deltaTime), pointlight.transform.localScale.z);
                
                resizeTimer += Time.deltaTime;
                if (resizeTimer >= 0.018f)//resize each 0.02 seconds
                {
                    resizeTimer = 0f;
                    Candle.transform.localScale = new Vector3(Candle.transform.localScale.x, Candle.transform.localScale.y - resizePerFrameValue, Candle.transform.localScale.z);
                }
            }
            else
            {
                isBursting = false;
                //pointlight.transform.localScale = new Vector3(Candle.transform.localScale.y, 1, this.pointlight.transform.localScale.z);
                  if (pointlight.transform.localScale.x > Candle.transform.localScale.y)
                    pointlight.transform.localScale = new Vector3(pointlight.transform.localScale.x - lightresizeSpeed * Time.deltaTime, pointlight.transform.localScale.y, pointlight.transform.localScale.z);
                   else
                        pointlight.transform.localScale = new Vector3(Candle.transform.localScale.y, pointlight.transform.localScale.y, pointlight.transform.localScale.z);

                    if (pointlight.transform.localScale.y > 1f)
                       pointlight.transform.localScale = new Vector3(pointlight.transform.localScale.x, pointlight.transform.localScale.y - (lightresizeSpeed/Candle.transform.localScale.y)*Time.deltaTime, pointlight.transform.localScale.z);
                    else
                        pointlight.transform.localScale = new Vector3(pointlight.transform.localScale.x, 1f, pointlight.transform.localScale.z);
                
            }
        }
        if (CharacterController.PlayerNr == 2)
        {
            if (Input.GetAxis("Burst") == 1 && Candle.transform.localScale.y >= .1f)
            {
                //pointlight.transform.localScale = new Vector3(2f, (2f / Candle.transform.localScale.y));
                isBursting = true;
                //light scale
                if (pointlight.transform.localScale.x < 2f)
                    pointlight.transform.localScale = new Vector3(pointlight.transform.localScale.x + lightresizeSpeed * Time.deltaTime, pointlight.transform.localScale.y);

                if (pointlight.transform.localScale.y < (2f / Candle.transform.localScale.y))
                    pointlight.transform.localScale = new Vector3(pointlight.transform.localScale.x, pointlight.transform.localScale.y + ((lightresizeSpeed / Candle.transform.localScale.y) * Time.deltaTime), pointlight.transform.localScale.z);

                resizeTimer += Time.deltaTime;
                if (resizeTimer >= 0.018f)//resize each 0.02 seconds
                {
                    resizeTimer = 0f;
                    Candle.transform.localScale = new Vector3(Candle.transform.localScale.x, Candle.transform.localScale.y - resizePerFrameValue, Candle.transform.localScale.z);
                }
            }
            else
            {
                isBursting = false;
                //pointlight.transform.localScale = new Vector3(Candle.transform.localScale.y, 1, this.pointlight.transform.localScale.z);
                if (pointlight.transform.localScale.x > Candle.transform.localScale.y)
                    pointlight.transform.localScale = new Vector3(pointlight.transform.localScale.x - lightresizeSpeed * Time.deltaTime, pointlight.transform.localScale.y, pointlight.transform.localScale.z);
                else
                    pointlight.transform.localScale = new Vector3(Candle.transform.localScale.y, pointlight.transform.localScale.y, pointlight.transform.localScale.z);

                if (pointlight.transform.localScale.y > 1f)
                    pointlight.transform.localScale = new Vector3(pointlight.transform.localScale.x, pointlight.transform.localScale.y - (lightresizeSpeed / Candle.transform.localScale.y) * Time.deltaTime, pointlight.transform.localScale.z);
                else
                    pointlight.transform.localScale = new Vector3(pointlight.transform.localScale.x, 1f, pointlight.transform.localScale.z);

            }
        }
    }
}
