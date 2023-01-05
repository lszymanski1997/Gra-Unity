using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private int value;
    
    public void setValue(int val)
    {
        value = val;
    }

    public int getValue()
    {
        return value;
    }
}
