using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private int WaxAmount = 1;
    [SerializeField] private float WaxValue = 0.15f;
    private WaxController WaxController;
    [SerializeField] GameObject FloatingPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if ((collision.tag == "Player1" || collision.tag == "Player2") && collision.gameObject.GetComponent<WaxController>())
        {
            FloatingPoints.GetComponentInChildren<TextMesh>().text = "+" + WaxAmount + "Wax";
            Debug.Log(gameObject.transform.position);
            Instantiate<GameObject>(FloatingPoints, gameObject.transform.position, Quaternion.identity);
            Debug.Log(collision.gameObject.GetComponent<WaxController>());
            GetWax(collision.gameObject.GetComponent<WaxController>());
        }

    }
    public void GetWax(WaxController waxController)
    {
        waxController.WaxAmount += 1;
    }
}
