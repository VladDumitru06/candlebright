using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController Controller;
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private Canvas endtext;
    private float movementSpeed;
    private bool jump = false;
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.A)) // Right
        {
            movementSpeed = playerSpeed * -1;
            Debug.Log(movementSpeed);
        }
        else if (Input.GetKey(KeyCode.D)) // Left
        {
            movementSpeed = playerSpeed;
        }
        else
        {
            movementSpeed = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.localScale.y <= .1f)
        {
            endtext.enabled = true;
        }
        else
        {
            Controller.Move(movementSpeed, false, jump);
        }
    }
}
