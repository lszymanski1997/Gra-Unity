using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCube : MonoBehaviour
{
    public GameObject cube;

    List<(int,int)> list = new List<(int,int)>();

    // Start is called before the first frame update
    void Start()
    {
        for (int n = -4; n < 4; n++)
        {
            for (int m = -4; m < 4; m++)
            {
                list.Add((n, m));
            }
                
        }


        for(int n = 0; n < 10; n++)
        {
            int index = Random.Range(0, list.Count - 1);
            Instantiate(cube, new Vector3(list[index].Item1, 1, list[index].Item2), Quaternion.identity);
            list.Remove(list[index]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
