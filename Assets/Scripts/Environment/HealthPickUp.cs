using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healthBonus = 5;

    public float rotationSpeed = 180f;

    public void Start()
    {

    }

    public void Update()
    {
        gameObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }


}

