using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    [SerializeField] GameObject CeilingCheck;
    [SerializeField] GameObject Player;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = CeilingCheck.transform.position;
        if (Player.transform.localScale.z > 0)
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        if (Player.transform.localScale.z < 0)
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
    }
}
