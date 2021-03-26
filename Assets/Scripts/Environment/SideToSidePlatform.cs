using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSidePlatform : MonoBehaviour
{
    public GameObject Player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
