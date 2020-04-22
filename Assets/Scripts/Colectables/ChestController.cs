using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private int WaxAmount = 1;
    [SerializeField] private float WaxValue = 0.15f;
    bool player1 = false;
    bool player2 = false;
    private WaxController WaxController;
    [SerializeField] GameObject FloatingPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if ((collision.tag == "Player1" || collision.tag == "Player2") && collision.gameObject.GetComponent<WaxController>())
        {
            FloatingPoints.GetComponentInChildren<TextMesh>().color = collision.GetComponentInChildren<SpriteRenderer>().color +new Color(0f,0f,0f,-0.5f);
            if (player1 && collision.tag == "Player1")
            {
                
            FloatingPoints.GetComponentInChildren<TextMesh>().text = "NO MORE 4 U";
            Instantiate<GameObject>(FloatingPoints, gameObject.transform.position, Quaternion.identity);
            }
             if (player2 && collision.tag == "Player2")
            {
                FloatingPoints.GetComponentInChildren<TextMesh>().text = "NO MORE 4 U";
                Instantiate<GameObject>(FloatingPoints, gameObject.transform.position, Quaternion.identity);

            }
             if ((!player1 && collision.tag == "Player1" )|| (!player2 && collision.tag == "Player2"))
            {
                FloatingPoints.GetComponentInChildren<TextMesh>().text = "+" + WaxAmount + "Wax";
                GetWax(collision.gameObject.GetComponent<WaxController>());
                Instantiate<GameObject>(FloatingPoints, gameObject.transform.position, Quaternion.identity);
            }
            if (player1 && player2)
                Destroy(gameObject, 1f);
            if (collision.tag == "Player1")
            {
                player1 = true;
            }
            else if (collision.tag == "Player2")
            {
                player2 = true;
            }
        }

    }
    public void GetWax(WaxController waxController)
    {
        waxController.WaxAmount += 1;
    }
}
