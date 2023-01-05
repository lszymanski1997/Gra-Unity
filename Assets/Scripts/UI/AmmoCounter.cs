using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    public void setText(int val)
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Ammo : " + val;
    }
}
