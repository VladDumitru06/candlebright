using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoperSetter : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string ShootHook;
    [FMODUnity.EventRef]
    public string RopePull;
    public SpiderRope rope;
    private CharacterDeathController CDC;
    [SerializeField] CharacterController Ch;
    [SerializeField] GameObject ShootPoint;
    private bool IsHookShot;
    private FMOD.Studio.EventInstance RopePullInstance;
    void Start()
    {

        RopePullInstance = FMODUnity.RuntimeManager.CreateInstance(RopePull);
        IsHookShot = false;
        CDC = GetComponent<CharacterDeathController>();
    }

    void Update()
    {
       if (Ch.PlayerNr == 1)
        { 
            if (Input.GetMouseButtonDown(0))
            {

              Vector2 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
               rope.setStart(worldpos);
                FMODUnity.RuntimeManager.PlayOneShot(ShootHook);


            }
            if (Input.GetMouseButtonUp(0) &&  !Input.GetMouseButton(0))
            {
            rope.DestroyRope();
            }
        }
        if (Ch.PlayerNr == 2)
        {
            if (Input.GetAxis("ShootHook") == 1f && IsHookShot == false)
            {

                Vector2 Startpos = new Vector2(Input.GetAxis("HorizontalMove"), Input.GetAxis("VerticalMove")) + new Vector2(ShootPoint.transform.position.x, ShootPoint.transform.position.y);
                rope.setStart(Startpos);
                IsHookShot = true;
                FMODUnity.RuntimeManager.PlayOneShot(ShootHook);

            }
            if (Input.GetAxis("ShootHook") == 0)
            {
                IsHookShot = false;
                rope.DestroyRope();
            }
        }
    }
}
