using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    private float RollingSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = 0.1f;
        // x, y, z
        transform.Rotate(0, Time.deltaTime * RollingSpeed, Time.deltaTime * RollingSpeed);
        //transform.Rotate(Vector3.up * Time.deltaTime * RollingSpeed);
    }
}
