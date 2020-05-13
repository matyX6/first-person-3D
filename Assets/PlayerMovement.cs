using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller = null;
    [SerializeField] private Transform _groundCheck = null;
    [SerializeField] private float _groundDistance = .4f;
    [SerializeField] private LayerMask _groundMask = ~0;
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _gravity = -9.81f;
    private Vector3 _velocity;
    bool isGrounded;


    private void Update()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * _speed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }
}
