using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private int ammo;
    public int startingAmmo;

    // Start is called before the first frame update
    void Start()
    {
        ammo = startingAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getAmmo()
    {
        return ammo;
    }

    public void setAmmo(int val)
    {
        ammo = val;
    }
}
