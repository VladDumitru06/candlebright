using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpikeController : MonoBehaviour
{
    [SerializeField] CharacterDeathController DeathControllerP1;
    [SerializeField] CharacterDeathController DeathControllerP2;
    [SerializeField] private float resizespeed = .1f;
    float resizeTimer;
    float resizePerFrameValue;
    // Start is called before the first frame update
    private void Start()
    {
        resizeTimer = 0f;
        //resizePerFrameValue = (9 * Candle_FullSize.transform.localScale.y) / (10 * resizeSeconds * 50);
        resizePerFrameValue = (9 * 1) / (10 * 2 * 50);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
            DeathControllerP1.Death();
        if (collision.tag == "Player2")
            DeathControllerP2.Death();


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "LightCollider" && collision.gameObject.transform.localScale.y > .1f)
        {
            resizeTimer += Time.deltaTime;
            if (resizeTimer >= 0.018f)//resize each 0.02 seconds
            {
                Debug.Log(resizePerFrameValue);
                resizeTimer = 0f;
                this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y - 0.009f, this.transform.localScale.z) ;
            }

          //  gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.y -( resizespeed * Time.deltaTime));
        }
    }

    private void Update()
    {
        if(this.transform.localScale.y <= 0.1f)
        {
            Destroy(gameObject);
        }
    }

}
