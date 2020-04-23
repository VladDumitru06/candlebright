using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private int WaxAmount = 1;
    [SerializeField] private float WaxValue = 0.15f;
    [SerializeField] CharacterDeathController DeathControllerP1;
    [SerializeField] CharacterDeathController DeathControllerP2;
    public bool CanCollectWaxP1;
    public bool CanCollectWaxP2;
    private WaxController WaxController;
    [SerializeField] GameObject FloatingPoints;

    private void Start()
    {
        CanCollectWaxP1 = true;
        CanCollectWaxP2 = true;
        DeathControllerP1.HasRespawned.AddListener(ResetWaxP1);
        DeathControllerP1.HasRespawned.AddListener(ResetWaxP2);
    }
    void ResetWaxP1()
    {
        Debug.Log("RESETP1");
        CanCollectWaxP1 = true;
    }
    void ResetWaxP2()
    {
        Debug.Log("RESETP2");
        CanCollectWaxP2 = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if ((collision.tag == "Player1" || collision.tag == "Player2") && collision.gameObject.GetComponent<WaxController>())
        {
            FloatingPoints.GetComponentInChildren<TextMesh>().color = collision.GetComponentInChildren<SpriteRenderer>().color +new Color(0f,0f,0f,-0.5f);
            if (CanCollectWaxP1 == false && collision.tag == "Player1")
            {
                
            FloatingPoints.GetComponentInChildren<TextMesh>().text = "NO MORE 4 U";
            Instantiate<GameObject>(FloatingPoints, gameObject.transform.position, Quaternion.identity);
            }
             if (CanCollectWaxP2 == false && collision.tag == "Player2")
            {
                FloatingPoints.GetComponentInChildren<TextMesh>().text = "NO MORE 4 U";
                Instantiate<GameObject>(FloatingPoints, gameObject.transform.position, Quaternion.identity);

            }
             if ((CanCollectWaxP1 == true && collision.tag == "Player1" )|| (CanCollectWaxP2 == true && collision.tag == "Player2"))
            {
                FloatingPoints.GetComponentInChildren<TextMesh>().text = "+" + WaxAmount + "Wax";
                GetWax(collision.gameObject.GetComponent<WaxController>());
                Instantiate<GameObject>(FloatingPoints, gameObject.transform.position, Quaternion.identity);
            }
            if (collision.tag == "Player1")
            {
                CanCollectWaxP1 = false;
            }
            else if (collision.tag == "Player2")
            {
                CanCollectWaxP2 = false;
            }
        }

    }
    public void GetWax(WaxController waxController)
    {
        waxController.WaxAmount += 1;
    }
}
