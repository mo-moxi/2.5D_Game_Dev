using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;

    [SerializeField] private float _jumpHeight = 15.0f;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(_horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = _jumpHeight;
            }
        }
        else
        {
            velocity.y -= _gravity;
        }

        _controller.Move(velocity * Time.deltaTime);
    }
}
