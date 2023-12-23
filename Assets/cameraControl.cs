using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move camera with WASD keys
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * 100);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 100);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * 100);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 100);
        }
        
        // zoom in and out with mouse wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 100);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 100);
        }

        // rotate camera with Q and E
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 100);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 100);
        }

    }
}
