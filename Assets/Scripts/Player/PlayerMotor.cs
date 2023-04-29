using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    public float speed = 5f;
    private bool _isGrounded;
    public float gravity = -9.8f;
    public float _jumpHeight = 3f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _controller.isGrounded;
    }
    //recieve input for inputmanager
    public void ProcessMove(Vector2 input)
    {
        var moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection) * (speed * Time.deltaTime));
        _playerVelocity.y += gravity * Time.deltaTime;
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }
        _controller.Move(_playerVelocity * Time.deltaTime);
        Debug.Log(_playerVelocity.y);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3.0f * gravity);
        }
    }
    
    
    
}
