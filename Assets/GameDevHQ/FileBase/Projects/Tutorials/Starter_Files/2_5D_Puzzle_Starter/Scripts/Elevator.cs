using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    private bool _goingDown = false;
    [SerializeField]
    private float _speed = 2.5f;

public void CallElevator()
{
    _goingDown = !_goingDown;
}

void FixedUpdate()
{
    if (_goingDown == true)
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
    }
    else if (_goingDown == false)
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
    }    
}
private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }
private void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        other.transform.parent = null;
    }
}
}
