﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaxController : MonoBehaviour
{
    [SerializeField] GameObject Candle;
    [SerializeField] float WaxValue = .15f;
    public int WaxAmount;
    
    public void UseWax()
    {
        if (WaxAmount > 0 && Candle.transform.localScale.y < 1f)
        { 
            if (Candle.transform.localScale.y+WaxValue > 1f)
            {
                Candle.transform.localScale = new Vector3(Candle.transform.localScale.x, 1f, Candle.transform.localScale.z);
            }
            else
            {
                Candle.transform.localScale = new Vector3(Candle.transform.localScale.x, Candle.transform.localScale.y + WaxValue, Candle.transform.localScale.z);
            }
            WaxAmount -= 1;
        }
    }
}