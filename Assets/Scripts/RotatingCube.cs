using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate in x,y,z value with Time.deltaTime so it will rotate smoothly instead of rapid spining
        transform.Rotate(new Vector3(15,30,45)*Time.deltaTime);
    }
}
