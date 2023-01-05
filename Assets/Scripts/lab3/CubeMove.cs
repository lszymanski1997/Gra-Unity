using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float speed = 1f;
    bool back = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 10)
        {
            back = true;
        }

        if(transform.position.x <= 0)
        {
            back = false;
        }

        if (back)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (!back)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
