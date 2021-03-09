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
            if (other.transform.position.x <= this.transform.position.x)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
                MeshRenderer renderer = GetComponentInChildren<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.blue;
                }
                Debug.Log("Name: " + this.name);
                Destroy(this);    
            }
        }
    }
}// remember to ALWAYS error check object components