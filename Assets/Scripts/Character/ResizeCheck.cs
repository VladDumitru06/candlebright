using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeCheck : MonoBehaviour
{
    [SerializeField] GameObject Cellingcheck;
    private bool canGrow = true;
    public bool CanGrow { get { return canGrow; } }
    private void Update()
    {
        this.transform.position = Cellingcheck.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Debug.Log("TRUE");
            canGrow = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("FALSE");
        canGrow = true;
    }
}
