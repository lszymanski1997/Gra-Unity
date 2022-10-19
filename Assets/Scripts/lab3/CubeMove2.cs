using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove2 : MonoBehaviour
{
    public float speed = 3f;
    Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(lastPos,transform.position) >= 10)
        {
            lastPos = transform.position;
            transform.Rotate(0, 90, 0, Space.World);
        }
        else
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
        }
    }
}
