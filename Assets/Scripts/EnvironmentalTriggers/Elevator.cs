using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 4f;
    public GameObject movePlatform;
    private void OnTriggerStay(Collider other)
    {
        movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime * speed;

    }
}
