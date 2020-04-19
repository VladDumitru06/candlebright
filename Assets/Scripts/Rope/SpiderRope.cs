using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderRope : MonoBehaviour
{
    [SerializeField] float maxropesize = 50f; // the length the rope can be shot at
    [SerializeField] float stayTime = 1f;// Time until the hook breaks
    [SerializeField] public Material mat; // the material of the rope
    [SerializeField] public Rigidbody2D Player; // The Rigidbody of the player (pivot point at feet)
    [SerializeField] GameObject origin;// The Rigidbody of The CellingCheck GameObject attached to the head of the Player (for shooting web out of )
    [SerializeField] float line_width = .1f;// the width of the line
    [SerializeField] float speed = 25;// the speed the rope is shot with
    [SerializeField] float pull_force = 3f;// the force the rope pulls the Player
    public bool IsSwinging;
    private LineRenderer line;// the Line itself
    private float pull_force_temp;// Temporary pull force to increase while hook is attached
    private Vector3 velocity; // the velocity of the gameobject
    private IEnumerator timer;// timer for Coroutine
    private bool update = false; // check if update should be run
    private bool TriggerStay = false; // For OnTriggerStay2D (Better accuracy)
    private bool pull = false; // Check if the player should be pullde
    void Start()
    {
        pull_force_temp = pull_force;
        line = GetComponent<LineRenderer>(); // Create line
        if (!line)
        {
            line = gameObject.AddComponent<LineRenderer>();
        }
        line.startWidth = line_width; //define width
        line.endWidth = line_width; //define height
        line.material = mat; //define material
    }

    public void setStart(Vector2 targetPos)//Set the starting position of the hook and the timer
    {
        Vector2 dir = (targetPos - new Vector2( origin.transform.position.x, origin.transform.position.y)); // get direction
        dir = dir.normalized;
        velocity = dir * speed;
        transform.position = new Vector2(origin.transform.position.x, origin.transform.position.y) + dir; //shot first direction
        IsSwinging = true;
        pull = false;//don't pull you, not grabed to anything
        update = true;//start update function

        if (timer != null)//start the timer
        {
            StopCoroutine(timer);
            timer = null;
        }
    }
    void Update()
    {
        if (!update)
        {
            return;//do nothing
               
        }
        float distance = Vector2.Distance(transform.position, new Vector2(origin.transform.position.x, origin.transform.position.y));//distance from the target to the head of the characther
        if (pull)
        {
            Vector2 dir = (Vector2)transform.position - new Vector2(origin.transform.position.x, origin.transform.position.y);//direction to pull towards
            pull_force_temp += Time.deltaTime;//increas pull force
                Player.AddForce(dir * pull_force_temp);// apply pull force
        }
        else
        {

            transform.position += velocity * Time.deltaTime; // shoot the rope
            
            if (distance > maxropesize) // check for distance so rope doesn't shoot for infinity and make the rope dissapear
            {
                update = false;
                line.SetPosition(0, Vector2.zero) ;
                line.SetPosition(1, Vector2.zero);
                return;
            }
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, new Vector2(origin.transform.position.x, origin.transform.position.y));
    }
    IEnumerator reset (float delay)
    {
        yield return new WaitForSeconds(delay);//Timer to make rope dissapear when it passed
            update = false;
            line.SetPosition(0, Vector2.zero);
            line.SetPosition(1, Vector2.zero);
            TriggerStay = false;
            IsSwinging = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        velocity = Vector2.zero; // Attach to the object it collided with
        pull = true;
        timer = reset(stayTime);
        StartCoroutine(timer);
        pull_force_temp = pull_force;
    }
    private void OnTriggerStay2D(Collider2D collision) //for extra accuracy 
    {
        if (TriggerStay == false)// run only the first execution
        {
            velocity = Vector2.zero;
            pull = true;
            timer = reset(stayTime);
            StartCoroutine(timer);
            pull_force_temp = pull_force;
            TriggerStay = true; 
        }

    }
    public void DestroyRope()//destroy the rope
    {
        update = false;
        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, Vector2.zero);
        TriggerStay = false;
        StopAllCoroutines();
        IsSwinging = false;
    }
}
