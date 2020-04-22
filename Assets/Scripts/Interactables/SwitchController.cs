using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] SpriteRenderer SwitchColor;
    [SerializeField] GameObject ToMove;
    [SerializeField] float MovementSpeed = 2f;
    [SerializeField] Vector2 EndPoint;
    Vector2 StartPoint;
    Color Red , Green;
    bool ReturnToOrigin = false;
    void Start()
    {
        StartPoint = ToMove.transform.position;
        Red = new Color(.8627f, .0784f, .2352f);
        Green = new Color(.1960f, .8039f, .1960f);
        SwitchColor.color = Red;
        Debug.Log(SwitchColor.color.r + " " + SwitchColor.color.g + " " + SwitchColor.color.b);
    }
    private void FixedUpdate()
    {
        if (ReturnToOrigin)
        {
            if (EndPoint.x == ToMove.transform.position.x)
            {
                Debug.Log("RETURNING TO ORIGIN");
                ToMove.transform.position = new Vector2(ToMove.transform.position.x,ToMove.transform.position.y - MovementSpeed *Time.deltaTime);
                if (ToMove.transform.position.y == StartPoint.y)
                {
                    ReturnToOrigin = false;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "LightCollider")
        {
            Enabled();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "LightCollider")
        {
            Enabled();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "LightCollider")
        {
            Disabled();
        }
    }
    private void Disabled()
    {
        ReturnToOrigin = true;
        SwitchColor.GetComponent<SpriteRenderer>().color = Red;
    }
    private void Enabled()
    {
        ReturnToOrigin = false;
        Debug.Log(EndPoint.x  + " " + ToMove.transform.position.x);
        if (EndPoint.x == ToMove.transform.position.x && !(ToMove.transform.position.y >= EndPoint.y))
        {
            Debug.Log("MOVING TO ENDPOINT");
            ToMove.transform.position = new Vector2(ToMove.transform.position.x, ToMove.transform.position.y + MovementSpeed * Time.deltaTime);
        }
        SwitchColor.GetComponent<SpriteRenderer>().color = Green;

    }
}
