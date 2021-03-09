using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Movable_Box")
        { 
            Debug.Log(transform.position+" "+other.transform.position.x);
            if (other.transform.position.x == transform.position.x)
            {
                Debug.Log("in pos");
                other.GetComponent<Rigidbody>().mass = 100;
            }
        }
    }
}
