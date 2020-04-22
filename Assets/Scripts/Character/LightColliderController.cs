using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColliderController : MonoBehaviour
{
    [SerializeField] GameObject Light;
    [SerializeField] GameObject Candle;
    [SerializeField] CharacterLightController CLC;
    // Update is called once per frame
    void Update()
    {
        Resize();
    }
    private void Resize()
    {
        this.transform.position = Light.transform.position;
        if (CLC.IsBursting == true)
        {
            this.transform.localScale = new Vector3(2f, 2f, 2f);
        }
        if (CLC.IsBursting == false)
        {
            this.transform.localScale = new Vector3(Candle.transform.localScale.y, 0, this.transform.localScale.z); ;
        }
    }
}
