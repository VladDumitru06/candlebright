using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private static CheckpointManager instance;
    [SerializeField] public GameObject CandlesizeP1;
    [SerializeField] public GameObject CandlesizeP2;
    public Vector2 lastCheckPointPosP1; //Keep track of where to teleport
    public Vector2 lastCheckPointPosP2;//Keep track of where to teleport
    public Vector3 lastCheckPointSizeP1;
    public Vector3 lastCheckPointSizeP2;

}
