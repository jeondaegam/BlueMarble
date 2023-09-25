using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingCoin : MonoBehaviour
{
    [SerializeField]
    public float RollingSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = 0.1f;
        // x, y, z
        transform.Rotate(0, Time.deltaTime * RollingSpeed, 0);
        //transform.Rotate(Vector3.up * Time.deltaTime * RollingSpeed);
    }
}
