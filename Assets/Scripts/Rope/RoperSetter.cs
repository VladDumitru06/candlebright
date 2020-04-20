using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoperSetter : MonoBehaviour
{
    public SpiderRope rope;
    private CharacterDeathController CDC;
    void Start()
    {
        CDC = GetComponent<CharacterDeathController>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

              Vector2 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
               rope.setStart(worldpos);
        }
        if (Input.GetMouseButtonUp(0))
        {

            rope.DestroyRope();
        }
    }
}
