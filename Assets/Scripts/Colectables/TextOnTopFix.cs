using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnTopFix : MonoBehaviour
{
    void Start()
    {
        GetComponent<MeshRenderer>().sortingLayerName = "TopLayer";
        GetComponent<MeshRenderer>().sortingOrder = 999;
    }

}
