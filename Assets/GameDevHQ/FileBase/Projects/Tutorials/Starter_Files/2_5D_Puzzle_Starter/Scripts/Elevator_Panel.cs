using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Panel : MonoBehaviour
{
    [SerializeField] private MeshRenderer _CallButton;
    [SerializeField] private GameObject _elevator;
    [SerializeField] private int _requiredCoins;
    private bool _elevatorCalled;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && other.GetComponent<Player>().CoinCount() >= _requiredCoins)
            {
                if (_elevatorCalled == true)
                {
                    _CallButton.material.color = Color.red;
                }
                else
                {
                    _CallButton.material.color = Color.green;
                    _elevatorCalled = true;
                }

                _elevator.GetComponent<Elevator>().CallElevator();
            }
        }
    }
}
