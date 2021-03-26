using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDanger : MonoBehaviour
{
    // User Inputs
    public float degrees = 45.0f;
    public float amplitude = 5f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector3 offset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degrees, Time.deltaTime * degrees), Space.World);

        // Float up/down with a Sin()
        tempPos = offset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
    

