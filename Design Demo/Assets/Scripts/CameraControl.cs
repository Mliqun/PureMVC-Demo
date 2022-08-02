using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = -Input.GetAxis("Vertical");
        float mouser = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(v * 20, mouser * 500, h * 20) * Time.deltaTime, Space.World);
    }
}
