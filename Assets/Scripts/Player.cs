using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    private float _yVelocity;
    [SerializeField] 
    private float _jumpHeight = 15.0f;
    private bool _canDoubleJump = false;
    private UIManager _uiManager;
    private int _coins;
    private Vector3 _startPosition;
    [SerializeField]
    private int _lives = 3;
    void Start()
    {
        _startPosition = transform.position;
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager == null)
            Debug.Log("UI is NULL");
        _uiManager.UpdateLivesDisplay(_lives);
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
                _canDoubleJump = true;
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;    
                }
            }

            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        
        _controller.Move(velocity * Time.deltaTime);
        if (transform.position.y < -10)
        {
            Damage();
        }
 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Coin")
        {
            _coins++;
            _uiManager.UpdateCoinsDisplay(_coins);
            Destroy(other.gameObject);
        }
    }
    public void Damage()
    {
        _lives--;
        _uiManager.UpdateLivesDisplay(_lives);
        transform.position = _startPosition;
        if(_lives < 1)
            SceneManager.LoadScene(0);
    }
}

